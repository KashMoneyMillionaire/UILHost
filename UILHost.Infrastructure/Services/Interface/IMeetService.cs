using System.Collections.Generic;
using UILHost.Infrastructure.Domain;
using UILHost.Patterns.Service;

namespace UILHost.Infrastructure.Services.Interface
{
    public interface IMeetService : IService<Meet>
    {
        IEnumerable<Meet> Read(long schoolId);
    }
}
