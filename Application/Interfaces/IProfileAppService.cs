using Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IProfileAppService : IGenericAppService<ProfileViewModel>
    {
        List<PermissionViewModel> GetPermissions(int idProfile);
        void Audit(Object obj, string method);
    }
}
