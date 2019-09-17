using System;
using System.Collections.Generic;
using System.Linq;
using Homeworks.Domain;
using Microsoft.EntityFrameworkCore;

namespace Homeworks.DataAccess
{
    public class SessionsRepository : BaseRepository<UserSession>
    {
        public SessionsRepository(DbContext context)
        {
            Context = context;
        }

        public override UserSession Get(Guid token)
        {
            return Context.Set<UserSession>()
                .First(x => x.Token == token);
        }

        public override IEnumerable<UserSession> GetAll()
        {
            return Context.Set<UserSession>().ToList();
        }
    }
}