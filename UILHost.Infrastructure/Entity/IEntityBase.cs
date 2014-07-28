using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Infrastructure.Entity
{
    public interface IEntityBase<TIdentityType> : IEntityBase
    {
        TIdentityType Id { get; }
    }

    /// <summary>
    /// Marker interface for classes in the domain model that are entities and not value objects
    /// </summary>
    public interface IEntityBase
    {
        bool IsNew { get; }
    }
}
