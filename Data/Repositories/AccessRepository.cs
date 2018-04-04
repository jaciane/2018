using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Domain.Entities;
using Data.Context;
using Dapper;

namespace Data.Repositories
{
    public class AccessRepository: GenericRepository<Access>, IAccessRepository
    {
        private ModelContext _context;


        public AccessRepository(ModelContext context):base(context)
        {
            _context = context;
        }

        public void Delete(Access obj)
        {
            _dbSet.Attach(obj);
            _dbSet.Remove(obj);
        }

        public Access GetByComposedKey(int param1, int param2)
        {
            return _dbSet.Find(param1, param2);
        }
    }
}
