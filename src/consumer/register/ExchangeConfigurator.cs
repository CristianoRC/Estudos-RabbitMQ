using RabbitMQ.Client;

namespace register
{
    public class ExchangeConfigurator
    {
        private readonly IConnection _connection;
        private readonly IModel _model;
        private readonly string _exchangeName = "register";
        private readonly string _logQueueName = "log";
        private readonly string _registerQueuName = "register-weather-forecast";

        public ExchangeConfigurator(IConnection rabbitConnection)
        {
            _connection = rabbitConnection;
            _model = _connection.CreateModel();
        }

        private void CreateExchange()
        {
            _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic);
        }

        private void CreateQueues()
        {
            _model.QueueDeclare(_logQueueName, true, false, false, null);
            _model.QueueDeclare(_registerQueuName, true, false, false, null);
        }

        private void BindQueues()
        {
            _model.QueueBind(_logQueueName, _exchangeName, "*");
            _model.QueueBind(_registerQueuName, _exchangeName, "register.*");
        }

        public void Configure()
        {
            CreateQueues();
            CreateExchange();
            BindQueues();
        }
    }
}