using Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        public ApplicationContext Context { get; }

        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public async Task<int> CommitAsync()
        {
            int affectedRows = 0;

            try
            {
                affectedRows = await SaveChangesAsync();

                if (_transaction != null) _transaction.Commit();

                return affectedRows;
            }
            catch (Exception)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                }

                return affectedRows;
            }
            finally
            {
                if (_transaction != null) _transaction.Dispose();
            }
        }

        public void Dispose()
        {
            if (Context != null) Context.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
