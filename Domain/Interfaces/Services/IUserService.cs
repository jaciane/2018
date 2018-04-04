using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IGenericService<User>
    {
        bool VerifyUserExists(User user);
        List<string> Delete(User user);
        List<string> UpdateProfile(User user);
    }
}
