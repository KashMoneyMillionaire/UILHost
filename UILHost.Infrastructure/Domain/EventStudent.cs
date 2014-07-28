using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class EventStudent : EntityBase<long>
    {
        public Event Event { get; set; }
        public Student Student { get; set; }
        public int? Score { get; set; }
    }
}
