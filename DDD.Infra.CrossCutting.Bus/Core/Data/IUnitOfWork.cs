using System.Threading.Tasks;

namespace DDD.Infra.CrossCutting.Bus.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}