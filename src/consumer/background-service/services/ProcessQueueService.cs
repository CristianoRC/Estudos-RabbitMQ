using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace background_service
{
    public class ProcessQueueService : BackgroundService
    {

        private IModel _channel;
        private readonly string _queueName = "register-weather-forecast";

        public ProcessQueueService(IConnection connection)
        {
            _channel = connection.CreateModel();
            _channel.BasicQos(0, 10, false);
        }

        private string getEventContent(BasicDeliverEventArgs eventArgs)
        {
            var body = eventArgs.Body.ToArray();
            return Encoding.UTF8.GetString(body);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (sender, ea) =>
           {
               await MessageProcessor.Process(getEventContent(ea));
               _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
           };

            _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);
        }
    }
}