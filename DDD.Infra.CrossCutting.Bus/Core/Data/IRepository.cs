using System;
using DDD.Infra.CrossCutting.Bus.Core.DomainObjects;

namespace DDD.Infra.CrossCutting.Bus.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}