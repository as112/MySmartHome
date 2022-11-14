using MQTTnet;
using MQTTnet.Client;
using MySmartHomeWebApi.Data;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Models;
using System.Text;


namespace MySmartHomeWebApi.Servises
{
    public class MQTTClient
    {
        private readonly ILogger<MQTTClient> _logger;
        private readonly DbHistoryRepository<HistoryData> _historyRepository;
        private readonly DbEntityRepository<Lamps> _lampRepo;
        private readonly DbEntityRepository<Sensors> _sensorRepo;
        private readonly IEnumerable<string> _lampsTopics;
        private readonly IEnumerable<string> _sensorsTopics;

        private MqttFactory _mqttFactory;
        private IMqttClient _client;
        public IMqttClient Client { get => _client; private set => _client = value; }

        private string _mqttServer;
        private int _mqttServerPort;
        private string _mqttUserName;
        private string _mqttUserPassword;
        private string _mqttTopicPrefix;

        public MQTTClient(IConfiguration configuration, 
            ILogger<MQTTClient> logger, 
            IEntityRepository<Lamps> lampRepo, 
            IEntityRepository<Sensors> sensorRepo,
            IHistoryRepository<HistoryData> historyRepository)
        {
            _logger = logger;
            _historyRepository = (DbHistoryRepository<HistoryData>)historyRepository;
            _lampRepo = (DbEntityRepository<Lamps>)lampRepo;
            _sensorRepo = (DbEntityRepository<Sensors>)sensorRepo;
            var allLamps = _lampRepo.GetAll().Result;
            _lampsTopics = allLamps.Select(s => s.TopicDown!) ?? Enumerable.Empty<string>();
            var allSensors = _sensorRepo.GetAll().Result;
            _sensorsTopics = allSensors.Select(s => s.TopicUp) ?? Enumerable.Empty<string>();

            _mqttFactory = new MqttFactory();
            _client = _mqttFactory.CreateMqttClient();

            _mqttServer = (string)configuration.GetValue(typeof(string), "MqttServer");
            _mqttServerPort = (int)configuration.GetValue(typeof(int), "MqttServerPort");
            _mqttUserName = (string)configuration.GetValue(typeof(string), "MqttUserName");
            _mqttUserPassword = (string)configuration.GetValue(typeof(string), "MqttUserPassword");
            _mqttTopicPrefix = (string)configuration.GetValue(typeof(string), "MqttTopicPrefix");

            Task.Run(() => Run());
        }
        private async Task Run()
        {
            while (true)
            {
                if (!Client.IsConnected)
                    await ConnectAndSubscribeAsync();
                await Task.Delay(5000);
            }
        }

        public async Task PublishAsync(string topic, string value)
        {
            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(value)
                .Build();
            await Client.PublishAsync(applicationMessage, CancellationToken.None);
        }
        private async Task ConnectAndSubscribeAsync()
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

        private async Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            _logger.LogInformation($"Disconnection has occured. Trying to reconnect...");
            await Task.Delay(5000);
        }

        private async Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
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
        private async Task AddToDbSensor(DbEntityRepository<Sensors> sensorRepo, DbHistoryRepository<HistoryData> historyRepo, string topic, string value)
        {
            var sensors = await historyRepo.GetAllByTopic(topic);
            var sensor = sensors.Count() == 0 ? new HistoryData { Topic = topic } : sensors.OrderBy(s => s.DateTimeUpdate).Last();
            var sensorsByName = await sensorRepo.GetWithInclude(s => s.TopicUp == topic, null);
            var sensorByName = sensorsByName.OrderBy(s => s.DateTimeUpdate).Last();

            if (DateTime.Now.ToUniversalTime().AddMinutes(-2) >= sensor.DateTimeUpdate)
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

        private async Task AddToDbLamp(DbEntityRepository<Lamps> lampRepo, DbHistoryRepository<HistoryData> historyRepo, string topic, string value)
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
