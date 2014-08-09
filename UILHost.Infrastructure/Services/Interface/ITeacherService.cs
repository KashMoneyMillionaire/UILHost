using UILHost.Infrastructure.Domain;
using UILHost.Patterns.Service;

namespace UILHost.Infrastructure.Services.Interface
{
    public interface ITeacherService : IService<Teacher>
    {
        Teacher Read(string email);
    }
}
