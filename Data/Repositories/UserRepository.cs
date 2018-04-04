using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ModelContext _context;

        public UserRepository(ModelContext context): base(context)
        {
            _context = context;
        }

    }
}
