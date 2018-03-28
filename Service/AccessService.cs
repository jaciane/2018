using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Service
{
    public class AccessService : GenericService<Access>, IAccessService
    {
        private readonly IAccessRepository _accessRepository;

        public AccessService(IAccessRepository accessRepository) : base((IGenericRepository<Access>)accessRepository)
        {
            _accessRepository = accessRepository;
        }


        public Access GetByComposedKey(int param1, int param2)
        {
            return ((IComposedKeyGenericRepository<Access>)_accessRepository).GetByComposedKey(param1, param2);
        }

        public List<string> Delete(Access obj)
        {
            ((IComposedKeyGenericRepository<Access>)_accessRepository).Delete(obj);
            return new List<string>();
        }
    }
}
