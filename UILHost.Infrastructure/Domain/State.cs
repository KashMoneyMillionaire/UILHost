using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class State : EntityBase<long>
    {
        public int StateNum { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
}
