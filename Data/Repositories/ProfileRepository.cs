using System;
using System.Collections.Generic;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Dapper;

namespace Data.Repositories
{
    public class ProfileRepository: GenericRepository<Profile>, IProfileRepository
    {
        private ModelContext _context;

        public ProfileRepository(ModelContext context): base(context)
        {
            _context = context;
        }

        public List<Permission> GetPermissions(int idProfile)
        {
            var cn = _context.Database.Connection;
            var sql = string.Format(@"SELECT P.CLAIMTYPE AS ClaimType, P.CLAIMVALUE AS ClaimValue, P.ID AS Id FROM PERMISSION P
                    INNER JOIN ACCESS A ON A.ID_PERMISSION = P.ID
                    WHERE A.ID_PROFILE = {0}", idProfile);
            IEnumerable<Permission> next = cn.Query<Permission>(sql);
            return (List<Permission>)next;
        }
    }
}
