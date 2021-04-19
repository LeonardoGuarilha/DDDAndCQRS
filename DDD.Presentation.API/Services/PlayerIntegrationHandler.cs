using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Events;
using DDD.Domain.Interfaces;
using DDD.Infra.CrossCutting.Bus.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DDD.Presentation.API.Services
{
    public class PlayerIntegrationHandler : BackgroundService
    {
        
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PlayerIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }
        
        private void SetSubscribers()
        {
            _bus.SubscribeAsync<PlayerMongoRegisteredEvent>("PlayerMongoRegisteredEvent", async request => 
                await IntegrationPlayerMongo(request));
        }

        public async Task IntegrationPlayerMongo(PlayerMongoRegisteredEvent message)
        {
            using (var scopeRepository = _serviceProvider.CreateScope())
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var playerRepositoryMongo = scope.ServiceProvider.GetRequiredService<IPlayerRepositoryMongoDb>();
                    var playerRepository = scopeRepository.ServiceProvider.GetRequiredService<IPlayerRepository>();

                    var player = await playerRepository.GetById(message.Id);

                    if (player != null)
                    {
                        playerRepositoryMongo.Add(player);
                    }
                }   
            }
        }
    }
}