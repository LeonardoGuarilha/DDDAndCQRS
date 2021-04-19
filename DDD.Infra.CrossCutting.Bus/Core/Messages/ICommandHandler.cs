using System.Threading.Tasks;
using DDD.Infra.CrossCutting.Bus.Core.Data;

namespace DDD.Infra.CrossCutting.Bus.Core.Messages
{
    public interface ICommandHandler
    {
        Task<CommandResult> PersistirDados(IUnitOfWork uow);
    }
}