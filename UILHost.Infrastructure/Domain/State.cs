using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    public class State : EntityBase<long>
    {
        public int Number { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
