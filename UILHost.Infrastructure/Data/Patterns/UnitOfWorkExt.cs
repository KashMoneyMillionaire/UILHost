using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using UILHost.Patterns.Repository.DataContext;
using UILHost.Patterns.Repository.EF6;

namespace UILHost.Infrastructure.Data.Patterns
{
    /// <summary>
    /// Extends the generic repository pattern EF6 unit of work implementation to accomidate required
    /// Pavlos features (e.g., change data capture)
    /// </summary>
    public class UnitOfWorkExt : UnitOfWork
    {
        private ILog log = LogManager.GetLogger(typeof(UnitOfWorkExt));

        private readonly IDataContextAsync _context;
        private readonly UnitOfWorkCommitActivities _commitActivities;

        public UnitOfWorkExt(
            IDataContextAsync context)
            : base(context)
        {
            this._context = context;
            _commitActivities = new UnitOfWorkCommitActivities();
        }

        public void AddCommitActivity(Func<Task> activity) { _commitActivities.Add(activity); }

        public override int SaveChanges()
        {
            var saveResult = base.SaveChanges();
            _commitActivities.PerformCommitActivities().Wait();
            return saveResult;
        }

        public override Task<int> SaveChangesAsync()
        {

            return base.SaveChangesAsync()
                .ContinueWith(task =>
                {
                    if (task.Exception != null)
                        task.Exception.Handle(ex =>
                        {
                            this.log.Error("An asynchrounous save activity failed", ex);
                            return false;
                        });

                    _commitActivities.PerformCommitActivities().Wait();
                    return task.Result;
                });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken)
                .ContinueWith(task =>
                {
                    if (task.Exception != null)
                        task.Exception.Handle(ex =>
                        {
                            this.log.Error("An asynchrounous save activity failed", ex);
                            return false;
                        });

                    _commitActivities.PerformCommitActivities().Wait(cancellationToken);
                    return task.Result;
                }, cancellationToken);
        }

    }
}
