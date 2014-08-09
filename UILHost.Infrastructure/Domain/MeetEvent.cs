using System.Collections.Generic;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class MeetEvent : EntityBase<long>
    {
        public Meet Meet { get; set; }
        public Event Event { get; set; }
        public List<EventStudent> EventStudents { get; set; }
    }
}
