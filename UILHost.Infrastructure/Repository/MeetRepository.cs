using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILHost.Infrastructure.Domain;
using UILHost.Patterns.Repository.Repositories;

namespace UILHost.Infrastructure.Repository
{
    public static class MeetRepository
    {
        public static IEnumerable<Meet> Read(this IRepositoryAsync<Meet> repo, long schoolId)
        {
            return repo.Queryable().Where(s => s.HostSchool.Id == schoolId);
        }
    }
}
