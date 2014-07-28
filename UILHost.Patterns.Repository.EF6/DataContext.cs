using UILHost.Patterns.Repository.DataContext;
using UILHost.Patterns.Repository.Infrastructure;
using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace UILHost.Patterns.Repository.EF6
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
    public class DataContext : DbContext, IDataContext, IDataContextAsync
    {
        private readonly Guid _instanceId;

        public DataContext(string nameOrConnectionString, bool enableEfAutoDetectChanges = true)
            : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
            Configuration.AutoDetectChangesEnabled = enableEfAutoDetectChanges;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public Guid InstanceId
        {
            get { return _instanceId; }
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            SyncObjectsStatePreCommit();
            var changes = base.SaveChanges();
            SyncObjectsStatePostCommit();
            return changes;
        }

        public override async Task<int> SaveChangesAsync()
        {
            SyncObjectsStatePreCommit();
            var changesAsync = await base.SaveChangesAsync();
            SyncObjectsStatePostCommit();
            return changesAsync;
        }

        // JTH - Added to support mock data generation
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
             return Database.ExecuteSqlCommand(sql, parameters);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            SyncObjectsStatePreCommit();
            var changesAsync = await base.SaveChangesAsync(cancellationToken);
            SyncObjectsStatePostCommit();
            return changesAsync;
        }

        public void SyncObjectState(object entity)
        {
            Entry(entity).State = StateHelper.ConvertState(((IObjectState)entity).ObjectState);
        }

        private void SyncObjectsStatePreCommit()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
                dbEntityEntry.State = StateHelper.ConvertState(((IObjectState)dbEntityEntry.Entity).ObjectState);
        }

        public void SyncObjectsStatePostCommit()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
                ((IObjectState)dbEntityEntry.Entity).ObjectState = StateHelper.ConvertState(dbEntityEntry.State);
        }
    }
}
