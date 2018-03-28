using Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IUserAppService : IGenericAppService<UserViewModel>
    {
        List<string> UpdateProfile(UserViewModel obj);
        void Audit(Object obj, string method);
    }
}
