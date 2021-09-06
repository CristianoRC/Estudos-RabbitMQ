using System;
using RabbitMQ.Client;

namespace background_service
{
    public class ConnectionRabbitMq
    {

        private readonly string _connectionString;

        public ConnectionRabbitMq()
        {
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }


        public IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(_connectionString);
            factory.ClientProvidedName = "app:register:consumer";
            factory.DispatchConsumersAsync = true;

            return factory.CreateConnection();
        }
    }
}