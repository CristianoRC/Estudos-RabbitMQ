using System;
using RabbitMQ.Client;

namespace background_service
{
    public class ConnectionFacotry
    {

        private readonly string _connectionString;

        public ConnectionFacotry()
        {
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }


        public IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(_connectionString);
            factory.ClientProvidedName = "app:register";
            factory.DispatchConsumersAsync = true;

            return factory.CreateConnection();
        }
    }
}