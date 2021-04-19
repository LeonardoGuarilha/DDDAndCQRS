using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Events;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.CrossCutting.Bus.Core.Messages;
using DDD.Infra.CrossCutting.Bus.MessageBus;
using Flunt.Notifications;
using MediatR;

namespace DDD.Domain.Commands
{
    public class PlayerCommandHandler : Notifiable,
        IRequestHandler<RegisterNewPlayerCommand, CommandResult>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMessageBus _messageBus;
        private readonly ICommandHandler _commandHandler;

        public PlayerCommandHandler(IPlayerRepository playerRepository,
            IMessageBus messageBus,
            ICommandHandler commandHandler
            )
        {
            _playerRepository = playerRepository;
            _messageBus = messageBus;
            _commandHandler = commandHandler;
        }
        
        public async Task<CommandResult> Handle(RegisterNewPlayerCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            
            if (request.Invalid)
            {
                AddNotifications(request);
                return new CommandResult(false, "Não foi possível criar o jogador", null);
            }

            var player = new Player(request.Name, request.TeamId);
            
            player.AdicionarEvento(new PlayerRegisteredEvent(player.Id, request.Name, request.TeamId));
            
            _playerRepository.Add(player);
            
            await _commandHandler.PersistirDados(_playerRepository.UnitOfWork);
            
            // Lançar mensagem do PlayerRegisteredMongo
            await _messageBus.PublishAsync(
                new PlayerMongoRegisteredEvent(player.Id, request.Name, request.TeamId));

            return new CommandResult(true, "Jogador criado com sucesso", player);
        }
    }
}