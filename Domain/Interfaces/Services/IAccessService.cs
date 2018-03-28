using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IAccessService : IComposedKeyGenericService<Access>, IGenericService<Access>
    {
    }
}
