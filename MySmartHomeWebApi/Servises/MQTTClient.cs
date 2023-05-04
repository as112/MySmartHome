using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MQTTnet;
using MQTTnet.Client;
using MySmartHome.DAL.Data;
using MySmartHome.DAL.Models;
using MySmartHome.DAL.Repositories.Interfaces;
using System;
using System.Text;
using System.Threading.Channels;


namespace MySmartHomeWebApi.Servises
{
    public static class MQTTClient
    {
        private static ILogger<HistoryData>? _logger;
        private static IEnumerable<string>? _lampsTopics;
        private static IEnumerable<string>? _sensorsTopics;
        private static MqttFactory? _mqttFactory;
        private static IMqttClient? _client;
        private static string _connectionString;

        public static IMqttClient Client { get => _client; private set => _client = value; }

        private static string? _mqttServer;
        private static int _mqttServerPort;
        private static string? _mqttUserName;
        private static string? _mqttUserPassword;
        private static string? _mqttTopicPrefix;

        public static async Task MqttClientInit(IConfiguration configuration,
            ILogger<HistoryData> logger)
        {
            _logger = logger;
            _mqttFactory = new MqttFactory();
            _client = _mqttFactory.CreateMqttClient();

            _connectionString = configuration.GetConnectionString("MySmartHomeWebApiContext") ?? string.Empty;
            _mqttServer = configuration.GetValue<string>("MqttServer") ?? string.Empty;
            _mqttServerPort = configuration.GetValue<int>("MqttServerPort");
            _mqttUserName = configuration.GetValue<string>("MqttUserName") ?? string.Empty;
            _mqttUserPassword = configuration.GetValue<string>("MqttUserPassword") ?? string.Empty;
            _mqttTopicPrefix = configuration.GetValue<string>("MqttTopicPrefix") ?? string.Empty;
            
            var context = new FakeContext(_connectionString);
            var allLamps = await context.Lamps.AsQueryable().ToArrayAsync();
            _lampsTopics = allLamps.Select(s => s.TopicDown!) ?? Enumerable.Empty<string>();
            var allSensors = await context.Sensors.AsQueryable().ToArrayAsync();
            _sensorsTopics = allSensors.Select(s => s.TopicUp) ?? Enumerable.Empty<string>();
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
                await AddToDbLamp(arg.ApplicationMessage.Topic, Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
            }
            else if (_sensorsTopics.Contains(arg.ApplicationMessage.Topic))
            {
                await AddToDbSensor(arg.ApplicationMessage.Topic, Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
            }
        }
        private static async Task AddToDbSensor(string topic, string value)
        {
            var context = new FakeContext(_connectionString);
            var sensor = await context.HistoryData
                .AsQueryable()
                .Where(s => s.Topic == topic)
                .OrderByDescending(s => s.DateTimeUpdate)
                .FirstOrDefaultAsync();

            var sensorByName = await context.Sensors
                .AsQueryable()
                .Where(s => s.TopicUp == topic)
                .FirstOrDefaultAsync();
            
            if (DateTime.Now.ToUniversalTime().AddMinutes(-1) >= sensor.DateTimeUpdate)
            {
                var newSensor = new HistoryData();
                newSensor.Id = Guid.NewGuid();
                newSensor.Name = sensorByName.Name;
                newSensor.DateTimeUpdate = DateTime.Now;
                newSensor.Topic = sensorByName.TopicUp;
                newSensor.Value = value;
                await context.HistoryData.AddAsync(newSensor);
                _logger.LogInformation($"{topic} - {DateTime.Now.ToUniversalTime() - sensor.DateTimeUpdate}");
            }

            sensorByName.DateTimeUpdate = DateTime.Now;
            sensorByName.Value = value;
            context.Sensors.Update(sensorByName);
            await context.SaveChangesAsync();
            _logger.LogInformation($"Sensor {sensorByName.Name} has been updating");
        }

        private static async Task AddToDbLamp(string topic, string value)
        {
            var context = new FakeContext(_connectionString);

            var lampFromRepo = await context.Lamps
                .AsQueryable()
                .Where(s => s.TopicDown == topic)
                .FirstOrDefaultAsync();
            
            var newLampForHistory = new HistoryData();
            newLampForHistory.Id = Guid.NewGuid();
            newLampForHistory.DateTimeUpdate = DateTime.Now;
            newLampForHistory.Name = lampFromRepo.Name;
            newLampForHistory.Topic = lampFromRepo.TopicDown;
            newLampForHistory.Value = value;

            lampFromRepo.DateTimeUpdate = DateTime.Now;
            if (value == "0" && lampFromRepo.Status == true)
            {
                lampFromRepo.Status = false;
                context.Lamps.Update(lampFromRepo);
                await context.HistoryData.AddAsync(newLampForHistory);
                await context.SaveChangesAsync();
            }
            else if (value == "1" && lampFromRepo.Status == false)
            {
                lampFromRepo.Status = true;
                context.Lamps.Update(lampFromRepo);
                await context.HistoryData.AddAsync(newLampForHistory);
                await context.SaveChangesAsync();
            }
        }
    }

}
