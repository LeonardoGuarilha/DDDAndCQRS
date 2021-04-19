using System.Threading.Tasks;
using DDD.Infra.CrossCutting.Bus.Core.Messages;
using MediatR;

namespace DDD.Infra.CrossCutting.Bus.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<CommandResult> EnviarComando<T>(T comando) where T : ICommand
        {
            return await _mediator.Send(comando);
        }
    }
}