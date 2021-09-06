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

        private readonly IConnection _connection;

        public ProcessQueueService(IConnection connection)
        {
            _connection = connection;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var channel = _connection.CreateModel();
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ea) =>
           {
               Console.WriteLine($"Processando: {DateTime.Now.ToUniversalTime()}");
               var body = ea.Body.ToArray();
               var message = Encoding.UTF8.GetString(body);
               channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

           };

            var consumerTasks = channel.BasicConsume(queue: "register-weather-forecast", autoAck: false, consumer: consumer);
        }

    }
}