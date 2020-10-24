using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rpk_back.Application.Interfaces;
using Rpk_back.Domain.Models;

namespace Rpk_back.RabbitMQ.Client
{
    public class DataReceiver
    {
        private readonly IApplicationMemoryStore _memory;

        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private string _taskId;

        private readonly string _queueName;

        public DataReceiver(IApplicationMemoryStore memory)
        {
            _memory = memory;
            var factory = new ConnectionFactory { HostName = "localhost" };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _consumer = new EventingBasicConsumer(_channel);

            _queueName = _memory.GetCachedRegisteredNodes().FirstOrDefault()?.QueueChannel;

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
