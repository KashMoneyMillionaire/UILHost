using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class Student : EntityBase<long>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public School School { get; set; }

    }
}
