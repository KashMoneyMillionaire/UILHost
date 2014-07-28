using System;

namespace UILHost.Patterns.Repository.DataContext
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState(object entity);

        // need to be able to call this from insertGraph
        // consider changing the name of this function to something that makes more sense - as it is being called outside of a commit operation
        void SyncObjectsStatePostCommit();

        // JTH - Added to support mock data generation
        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
}