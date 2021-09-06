using System;
using System.Threading.Tasks;

namespace register
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var connectionFactory = new ConnectionFacotry();
            var connection = connectionFactory.GetConnection();
            var exchangeConfigurator = new ExchangeConfigurator(connection);
            exchangeConfigurator.Configure();
        }
    }
}
