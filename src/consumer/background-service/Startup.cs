
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace background_service
{
    public class Startup
    {

        private IConnection ConfigureConnection()
        {
            var connectionFactory = new ConnectionRabbitMq();
            var connection = connectionFactory.GetConnection();
            var exchangeConfigurator = new ExchangeConfigurator(connection);
            exchangeConfigurator.Configure();

            return connection;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = ConfigureConnection();
            services.AddSingleton<IConnection>(connection);
            services.AddHostedService<ProcessQueueService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
