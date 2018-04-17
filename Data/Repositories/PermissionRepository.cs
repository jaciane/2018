using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private ModelContext _context;

        public PermissionRepository(ModelContext context) : base(context)
        {
            _context = context;
        }
    }
}
