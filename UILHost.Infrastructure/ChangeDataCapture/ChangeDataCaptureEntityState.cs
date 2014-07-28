using System.Collections.Generic;
using System.Linq;

namespace UILHost.Infrastructure.ChangeDataCapture
{
    public enum ChangeDataCaptureEntityStatus
    {
        New,
        Updated,
        Deleted
    }

    public class ChangeDataCaptureEntityState
    {
        public Patterns.Repository.EF6.Entity Entity { get; set; }
        public ChangeDataCaptureEntityStatus Status { get; set; }
        public List<ChangeDataCapturePropertyState> PropertyStates { get; set; }

        public ChangeDataCaptureEntityState(Patterns.Repository.EF6.Entity entity, ChangeDataCaptureEntityStatus status)
        {
            this.Entity = entity;
            this.Status = status;
            this.PropertyStates = new List<ChangeDataCapturePropertyState>();
        }

        public bool HasChanges()
        {
            return this.PropertyStates.Any(s => s.HasChanges());
        }
    }
}
