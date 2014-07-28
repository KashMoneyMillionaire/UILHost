using UILHost.Infrastructure.ChangeDataCapture;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    [HideFromChangeDataCapture]
    public class ChangeDataAuditDetail : EntityBase<long>
    {
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
