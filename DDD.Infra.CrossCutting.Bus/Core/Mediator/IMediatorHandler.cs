using System.Threading.Tasks;
using DDD.Infra.CrossCutting.Bus.Core.Messages;

namespace DDD.Infra.CrossCutting.Bus.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<CommandResult> EnviarComando<T>(T comando) where T : ICommand;
    }
}