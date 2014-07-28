using System;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class Address : EntityBase<long>
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
    }

}
