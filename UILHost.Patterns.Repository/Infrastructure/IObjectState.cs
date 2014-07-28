
using System.ComponentModel.DataAnnotations.Schema;

namespace UILHost.Patterns.Repository.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}