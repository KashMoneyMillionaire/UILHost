using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class EventStudent : EntityBase<long>
    {
        public MeetEvent MeetEvent { get; set; }
        public Student Student { get; set; }
        public int? Score { get; set; }
    }
}
