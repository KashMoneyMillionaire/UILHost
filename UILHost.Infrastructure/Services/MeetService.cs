using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILHost.Infrastructure.Domain;
using UILHost.Infrastructure.Repository;
using UILHost.Infrastructure.Services.Interface;
using UILHost.Patterns.Repository.Repositories;
using UILHost.Patterns.Service;

namespace UILHost.Infrastructure.Services
{
    public class MeetService : Service<Meet>, IMeetService
    {
        private readonly IRepositoryAsync<Meet> _meetRepo;

        public MeetService(IRepositoryAsync<Meet> meetRepo)
            : base(meetRepo)
        {
            _meetRepo = meetRepo;
        }

        public IEnumerable<Meet> Read(long schoolId)
        {
            return _meetRepo.Read(schoolId);
        }
    }
}
