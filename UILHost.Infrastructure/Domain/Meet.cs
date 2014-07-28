using System;
using System.Collections.Generic;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class Meet : EntityBase<long>
    {
        public School HostSchool { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<School> Schools { get; set; }
        public List<MeetEvent> Events { get; set; }
        public List<Student> Students { get; set; } 
    }
}
