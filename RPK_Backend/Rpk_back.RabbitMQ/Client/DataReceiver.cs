using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rpk_back.Application.Interfaces;
using Rpk_back.Domain.Models;
using Rpk_back.RabbitMQ.Interfaces;

namespace Rpk_back.RabbitMQ.Client
{
    public class DataReceiver : IDataReceiver
    {
        private readonly QueueConfig _queueConfig;

        private readonly IApplicationMemoryStore _memory;

        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private string _taskId;

        private readonly string _queueName;

        private readonly ISensorService _sensorService;
        
        public DataReceiver(IApplicationMemoryStore memory,
            ISensorService sensorService,
            IOptions<QueueConfig> queueConfig)
        {
            _memory = memory;
            _sensorService = sensorService;

            _queueConfig = queueConfig.Value;

            var factory = new ConnectionFactory { HostName = _queueConfig.Host };

            var connection = factory.CreateConnection();

            _channel = connection.CreateModel();
            _consumer = new EventingBasicConsumer(_channel);

            _queueName = _memory.GetCachedRegisteredNodes().FirstOrDefault()?.QueueChannel ?? _queueConfig.QueueName;

            DeclareQueue();
        }

        protected void DeclareQueue()
        {
            _channel.QueueDeclare(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.BasicQos(
                prefetchSize: 0,
                prefetchCount: 1,
                global: false);
        }

        public void Receive()
        {
            _channel.BasicConsume(
                queue: _queueName,
                autoAck: false,
                consumer: _consumer);

            Console.WriteLine(" [x] Awaiting  requests");

            _consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var props = ea.BasicProperties;
                var replyProps = _channel.CreateBasicProperties();

                var json = Encoding.UTF8.GetString(body);

                try
                {
                    var data = JsonConvert.DeserializeObject<Sensor>(json);

                    _taskId = data.NodeId;

                    Console.WriteLine("Received: {0}", _taskId);

                    _sensorService.AddSensor(data);

                    replyProps.CorrelationId = props.CorrelationId;

                }
                catch (Exception e)
                {
                    // ignored
                }
            };
        }
    }
}
