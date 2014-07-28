
using UILHost.Patterns.Repository.Repositories;
using UILHost.Patterns.Service;
using UILHost.Infrastructure.Domain;
using UILHost.Infrastructure.Services.Interface;
using UILHost.Patterns.Repository.Repositories;
using UILHost.Patterns.Service;

namespace UILHost.Infrastructure.Services
{
    public class StateService : Service<State>, IStateService
    {
        public StateService(IRepositoryAsync<State> stateRepo)
            : base(stateRepo) { }
    }
}
