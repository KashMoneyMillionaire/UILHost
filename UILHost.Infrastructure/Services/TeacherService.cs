using UILHost.Infrastructure.Domain;
using UILHost.Infrastructure.Repository;
using UILHost.Infrastructure.Services.Interface;
using UILHost.Patterns.Repository.Repositories;
using UILHost.Patterns.Service;

namespace UILHost.Infrastructure.Services
{
    public class TeacherService : Service<Teacher>, ITeacherService
    {
        private readonly IRepositoryAsync<Teacher> _repository; 
        public TeacherService(IRepositoryAsync<Teacher> repository) : base(repository)
        {
            _repository = repository;
        }

        public Teacher Read(string email)
        {
            return _repository.Read(email);
        }
    }
}
