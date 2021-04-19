using DDD.Infra.CrossCutting.Bus.Core.Utils;
using DDD.Infra.CrossCutting.Bus.MessageBus;
using DDD.Presentation.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Presentation.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<PlayerIntegrationHandler>();
        }
    }
}