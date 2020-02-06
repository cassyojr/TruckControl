using Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationContext Context { get; }
        void BeginTransaction();
        Task<int> CommitAsync();
        void Rollback();
    }
}
