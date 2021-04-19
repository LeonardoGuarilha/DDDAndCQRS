using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Domain.Commands;
using DDD.Domain.Interfaces;
using DDD.Infra.CrossCutting.Bus.Core.Mediator;
using DDD.Infra.CrossCutting.Bus.Core.Messages;
using DDD.Infra.Data.Context;
using DDD.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IPlayerAppService, PlayerAppService>();
            service.AddScoped<IRequestHandler<RegisterNewPlayerCommand, CommandResult>, PlayerCommandHandler>();
            service.AddScoped<ICommandHandler, CommandHandler>();
            service.AddScoped<ICommandResult, CommandResult>();
            service.AddScoped<IPlayerRepository, PlayerRepository>();
            service.AddScoped<TournamentContext>();
            service.AddScoped<IMediatorHandler, MediatorHandler>();
            service.AddScoped<IPlayerRepositoryMongoDb, PlayerRepositoryMongoDb>();
        }
    }
}