namespace publisher
{
    public interface ISendMessageService
    {
        public void SendMessage(string message, string exchange, string routingKey);
        public void SendMessage(object message, string exchange, string routingKey);

    }
}