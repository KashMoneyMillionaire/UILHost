using UILHost.Patterns.Repository.Infrastructure;
using UILHost.Patterns.Repository.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace UILHost.Patterns.Repository.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : IObjectState;
    }
}