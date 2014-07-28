using System;
using System.Collections.Generic;
using System.Linq;
using UILHost.Patterns.Repository.Repositories;
using UILHost.Infrastructure.Domain;
using UILHost.Patterns.Repository.Repositories;

namespace UILHost.Infrastructure.Repository
{
    public static class StateRepository
    {
        public static State ReadById(this IRepositoryAsync<State> repo, long id)
        {
            return repo.Queryable()
                .FirstOrDefault(c => c.Id == id);
        }

        public static IEnumerable<State> ReadMultipleById(this IRepositoryAsync<State> repo, IEnumerable<long> ids)
        {
            return repo.Queryable()
                .Where(c => ids.Contains(c.Id))
                .AsEnumerable();
        }

        public static State ReadByCode(this IRepositoryAsync<State> repo, string code)
        {
            return repo.Queryable()
                .FirstOrDefault(c => c.StateCode == code);
        }

        public static State ReadByNum(this IRepositoryAsync<State> repo, string numberString)
        {
            //Returns 0 if can't convert
            var stateNumber = Convert.ToInt32(numberString);
            return repo.Queryable()
                .FirstOrDefault(c => c.StateNum == stateNumber);

        }
    }
}
