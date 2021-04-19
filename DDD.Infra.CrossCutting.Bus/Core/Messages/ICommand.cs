using MediatR;

namespace DDD.Infra.CrossCutting.Bus.Core.Messages
{
    public interface ICommand : IRequest<CommandResult>
    {
        void Validate();
    }
}