using UILHost.Patterns.Repository.Infrastructure;
using UILHost.Patterns.Repository.Repositories;
using System;
using System.Data;

namespace UILHost.Patterns.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : IObjectState;
        //IF 04/09/2014 Add IsolationLevel
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}