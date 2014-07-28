using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class MeetEvent : EntityBase<long>
    {
        public Meet Meet { get; set; }
        public Event Event { get; set; }
        public List<EventStudent> Students { get; set; }
    }
}
