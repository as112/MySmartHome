using MQTTnet;
using MQTTnet.Client;
using MySmartHome.DAL.Data;
using MySmartHome.DAL.Models;
using MySmartHome.DAL.Repositories.Interfaces;
using System.Text;


namespace MySmartHomeWebApi.Servises
{
    public static class MQTTClient
    {
        private static ILogger<HistoryData>? _logger;
        private static IHistoryRepository<HistoryData>? _historyRepository;
        private static IEntityRepository<Lamps>? _lampRepo;
        private static IEntityRepository<Sensors>? _sensorRepo;
        private static IEnumerable<string>? _lampsTopics;
        private static IEnumerable<string>? _sensorsTopics;

        private static MqttFactory? _mqttFactory;
        private static IMqttClient? _client;
        public static IMqttClient Client { get => _client; private set => _client = value; }

        private static string? _mqttServer;
        private static int _mqttServerPort;
        private static string? _mqttUserName;
        private static string? _mqttUserPassword;
        private static string? _mqttTopicPrefix;

        public static async Task MqttClientInit(IConfiguration configuration,
            ILogger<HistoryData> logger,
            IEntityRepository<Lamps> lampRepo,
            IEntityRepository<Sensors> sensorRepo,
            IHistoryRepository<HistoryData> historyRepository)
        {
            _logger = logger;
            _historyRepository = historyRepository;
            _lampRepo = lampRepo;
            _sensorRepo = sensorRepo;
            var allLamps = await _lampRepo.GetAll();
            _lampsTopics = allLamps.Select(s => s.TopicDown!) ?? Enumerable.Empty<string>();
            var allSensors = await _sensorRepo.GetAll();
            _sensorsTopics = allSensors.Select(s => s.TopicUp) ?? Enumerable.Empty<string>();

            _mqttFactory = new MqttFactory();
            _client = _mqttFactory.CreateMqttClient();

            _mqttServer = configuration.GetValue<string>("MqttServer") ?? string.Empty;
            _mqttServerPort = configuration.GetValue<int>("MqttServerPort");
            _mqttUserName = configuration.GetValue<string>("MqttUserName") ?? string.Empty;
            _mqttUserPassword = configuration.GetValue<string>("MqttUserPassword") ?? string.Empty;
            _mqttTopicPrefix = configuration.GetValue<string>("MqttTopicPrefix") ?? string.Empty;
        }
        public static async Task Run()
        {
            while (true)
            {
                if (!Client.IsConnected)
                    await ConnectAndSubscribeAsync();
                await Task.Delay(5000);
            }
        }

        public static async Task PublishAsync(string topic, string value)
        {
            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(value)
                .Build();
            await Client.PublishAsync(applicationMessage, CancellationToken.None);
        }
        private static async Task ConnectAndSubscribeAsync()
        {
            try
            {
                var options = new MqttClientOptionsBuilder()
                    .WithClientId("webapi")
                    .WithTcpServer(_mqttServer, _mqttServerPort)
                    .WithCredentials(_mqttUserName, _mqttUserPassword)
                    .WithCleanSession()
                    .Build();
                await Client.ConnectAsync(options);

                if (Client.IsConnected)
                {
                    _logger.LogInformation($"Connected successfully to broker: {_mqttServer}:{_mqttServerPort}");
                    var mqttSubscribeOptions = _mqttFactory.CreateSubscribeOptionsBuilder()
                        .WithTopicFilter(f => { f.WithTopic(_mqttTopicPrefix + "#"); })
                        .Build();

                    await Client.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
                    _logger.LogInformation($"Subscribed successfully for topic: {_mqttTopicPrefix + "#"}");
                }
                else
                    _logger.LogInformation($"Cannot to connect to broker: {_mqttServer}:{_mqttServerPort}");

                Client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;
                Client.DisconnectedAsync += Client_DisconnectedAsync;
            }
            catch (Exception e)
            {
                _logger.LogTrace(e, e.Message);
                await Client.DisconnectAsync();
            }
        }

        private static async Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            _logger.LogInformation($"Disconnection has occured. Trying to reconnect...");
            await Task.Delay(5000);
        }

        private static async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            if (_lampsTopics.Contains(arg.ApplicationMessage.Topic))
            {
                await AddToDbLamp(_lampRepo, _historyRepository, arg.ApplicationMessage.Topic, Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
            }
            else if (_sensorsTopics.Contains(arg.ApplicationMessage.Topic))
            {
                await AddToDbSensor(_sensorRepo, _historyRepository, arg.ApplicationMessage.Topic, Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
            }
        }
        private static async Task AddToDbSensor(IEntityRepository<Sensors> sensorRepo, IHistoryRepository<HistoryData> historyRepo, string topic, string value)
        {
            var sensors = await historyRepo.GetAllByTopic(topic);
            var sensor = sensors.Count() == 0 ? new HistoryData { Topic = topic } : sensors.OrderBy(s => s.DateTimeUpdate).Last();
            var sensorsByName = await sensorRepo.GetWithInclude(s => s.TopicUp == topic, null);
            var sensorByName = sensorsByName.OrderBy(s => s.DateTimeUpdate).Last();

            if (DateTime.Now.ToUniversalTime().AddMinutes(-1) >= sensor.DateTimeUpdate)
            {
                var newSensor = new HistoryData();
                newSensor.Id = Guid.NewGuid();
                newSensor.Name = sensorByName.Name;
                newSensor.DateTimeUpdate = DateTime.Now;
                newSensor.Topic = sensor.Topic;
                newSensor.Value = value;
                await historyRepo.Add(newSensor);
                _logger.LogError($"{topic} - {DateTime.Now.ToUniversalTime() - sensor.DateTimeUpdate}");
            }

            //double v = 0;
            //var payload = value.Replace('.', ',');
            //double.TryParse(payload, out v);
            sensorByName.DateTimeUpdate = DateTime.Now;
            sensorByName.Value = value;
            await sensorRepo.Update(sensorByName);
            _logger.LogError($"Sensor {sensorByName.Name} has been updating");
        }

        private static async Task AddToDbLamp(IEntityRepository<Lamps> lampRepo, IHistoryRepository<HistoryData> historyRepo, string topic, string value)
        {
            var lampsFromHistory = await historyRepo.GetAllByTopic(topic);
            var lastLampFromHistory = lampsFromHistory.Count() == 0 ? new HistoryData { Topic = topic } : lampsFromHistory.OrderBy(s => s.DateTimeUpdate).Last();
            var lampsFromRepo = await lampRepo.GetWithInclude(s => s.TopicDown == topic, null);
            var lampFromRepo = lampsFromRepo?.OrderBy(s => s.DateTimeUpdate).Last();

            var newLampForHistory = new HistoryData();
            newLampForHistory.Id = Guid.NewGuid();
            newLampForHistory.DateTimeUpdate = DateTime.Now;
            newLampForHistory.Name = lampFromRepo.Name;
            newLampForHistory.Topic = lastLampFromHistory.Topic;
            newLampForHistory.Value = value;

            lampFromRepo.DateTimeUpdate = DateTime.Now;
            if (value == "0" && lampFromRepo.Status == true)
            {
                lampFromRepo.Status = false;
                await lampRepo.Update(lampFromRepo);
                await historyRepo.Add(newLampForHistory);
            }
            else if (value == "1" && lampFromRepo.Status == false)
            {
                lampFromRepo.Status = true;
                await lampRepo.Update(lampFromRepo);
                await historyRepo.Add(newLampForHistory);
            }
        }
    }

}
