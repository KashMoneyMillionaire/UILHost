using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using UILHost.Infrastructure.ChangeDataCapture;
using UILHost.Patterns.Repository.DataContext;
using UILHost.Patterns.Repository.EF6;
using UILHost.Patterns.Repository.UnitOfWork;

namespace UILHost.Infrastructure.Data.Patterns
{
    /// <summary>
    /// Extends the generic repository pattern EF6 repository implementation to accomidate required
    /// Pavlos features (e.g., change data capture)
    /// </summary>
    /// <typeparam name="TEntity">The repository type</typeparam>
    public class RepositoryExt<TEntity> 
        : Repository<TEntity> where TEntity : UILHost.Patterns.Repository.EF6.Entity
    {
        private readonly IDataContextAsync _context;
        private readonly ChangeDataCaptureStateManager _stateManager;

        public RepositoryExt(
            IDataContextAsync context, 
            IUnitOfWorkAsync unitOfWork, 
            ChangeDataCaptureStateManager stateManager)
            : base(context, unitOfWork)
        {
            this._context = context;
            this._stateManager = stateManager;
        }

        public override void Insert(TEntity entity)
        {
            base.Insert(entity);
            this._stateManager.LogChanges((DbContext)this._context, entity, ChangeDataCaptureEntityStatus.New);
        }

        public override void Update(TEntity entity)
        {
            this._stateManager.LogChanges((DbContext)this._context, entity, ChangeDataCaptureEntityStatus.Updated);
            base.Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            base.Delete(entity);
            this._stateManager.LogChanges((DbContext)this._context, entity, ChangeDataCaptureEntityStatus.Deleted);
        }

        public override async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            this._stateManager.LogChanges((DbContext)this._context, await FindAsync(cancellationToken, keyValues), ChangeDataCaptureEntityStatus.Deleted);
            return await base.DeleteAsync(cancellationToken, keyValues);
        }
    }
}
