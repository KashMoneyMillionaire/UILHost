using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace UILHost.Infrastructure.Data.Patterns
{
    public class UnitOfWorkCommitActivities
    {
        private readonly ILog _log = LogManager.GetLogger(typeof (UnitOfWorkCommitActivities));

        readonly List<Func<Task>> _commitActivities = new List<Func<Task>>();

        public void Add(Func<Task> activity) { _commitActivities.Add(activity); }

        public async Task PerformCommitActivities()
        {
            foreach (var activity in _commitActivities)
            {
                try
                {
                    await activity();
                }
                catch (Exception ex)
                {
                    _log.Error("An error occured while completing a commit activity", ex);
                }
            }
        }
    }
}
