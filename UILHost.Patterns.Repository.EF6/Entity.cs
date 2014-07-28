using UILHost.Patterns.Repository.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace UILHost.Patterns.Repository.EF6
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}