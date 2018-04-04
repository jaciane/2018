using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces.Services;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using System.Web;

namespace Application
{
    public class ProfileAppService : GenericAppService, IProfileAppService
    {
        private readonly IProfileService _profileService;
        private readonly IPermissionService _permissionService;
        private readonly IAccessService _accessService;
        private readonly IUnitOfWork _uow;
        List<string> errors = new List<string>();
        //private readonly ILogErrorAppService _logErrorAppService;


        public ProfileAppService(IProfileService profileService, IPermissionService permissionService,
            IUnitOfWork uow, IAccessService accessService) : base(uow)
        {
            _profileService = profileService;
            _permissionService = permissionService;
            _uow = uow;
            _accessService = accessService;
        }

        public List<string> Delete(int id)
        {
            Profile profile = _profileService.GetById(id);
            if (profile == null)
            {
                errors.Add("Perfil não encontrado");
                return errors;
            }
            try
            {
                BeginTransaction();
                profile.Active = profile.Active.Equals(((int)GenericStatusEnum.Active).ToString()) ? ((int)GenericStatusEnum.Inactive).ToString() : ((int)GenericStatusEnum.Active).ToString();
                errors = _profileService.Update(profile);
                if (errors?.Count == 0)
                {
                    SaveChanges();
                    Commit();
                }
            }
            catch (Exception e)
            {
                Rollback();
                errors.Add(CodLogErrorEnum.CODELOGERROR.ToString());          
            }
            return errors;
        }

        public IEnumerable<ProfileViewModel> Get(Expression<Func<ProfileViewModel, bool>> filter = null, Expression<Func<IQueryable<ProfileViewModel>, IOrderedQueryable<ProfileViewModel>>> orderBy = null, string includeProperties = "")
        {
            var filterNew = filter != null ? AutoMapper.Mapper.Map<Expression<Func<ProfileViewModel, bool>>, Expression<Func<Profile, bool>>>(filter) : null;
            var orderByNew = orderBy != null ? AutoMapper.Mapper.Map<Expression<Func<IQueryable<ProfileViewModel>, IOrderedQueryable<ProfileViewModel>>>
                , Expression<Func<IQueryable<Profile>, IOrderedQueryable<Profile>>>>(orderBy) : null;
            return AutoMapper.Mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileViewModel>>(_profileService.Get(filterNew, orderByNew, includeProperties));
        }

        public IEnumerable<ProfileViewModel> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileViewModel>>(_profileService.GetAll()).OrderBy(q => q.Name);
        }

        public ProfileViewModel GetById(int id)
        {
            return AutoMapper.Mapper.Map<Profile, ProfileViewModel>(_profileService.GetById(id));
        }

        public List<string> Insert(ProfileViewModel obj)
        {
            List<Access> accessInserted = new List<Access>();
            try
            {
                BeginTransaction();
                Profile profile = AutoMapper.Mapper.Map<ProfileViewModel, Profile>(obj);
                profile.UserList = null;
                profile.AccessList = null;
                profile.Active = ((int)GenericStatusEnum.Active).ToString();
                errors = _profileService.Insert(profile);
                if (errors?.Count() == 0)
                {
                    if (obj.SelectedPermissionIdList != null)
                    {
                        foreach (var item in obj.SelectedPermissionIdList)
                        {
                            Access newAccess = new Access()
                            {
                                IdPermission = item,
                                IdProfile = profile.Id
                            };
                            _accessService.Insert(newAccess);
                            accessInserted.Add(newAccess);
                        }
                    }
                    SaveChanges();
                    Commit();
                }
            }
            catch (Exception e)
            {
                Rollback();
                errors.Add(CodLogErrorEnum.CODELOGERROR.ToString());
            }
            return errors;
        }

        public List<string> Update(ProfileViewModel obj)
        {
            List<Access> accessInserted = new List<Access>();
            try
            {
                BeginTransaction();
                Profile profile = AutoMapper.Mapper.Map<ProfileViewModel, Profile>(obj);
                errors = _profileService.Update(profile);
                if (errors?.Count() == 0)
                {
                    var IdPermissions = _profileService.GetPermissions(profile.Id).Select(p => p.Id).ToList();
                    foreach (var item in IdPermissions)
                    {
                        Access deleteAccess = new Access() { IdPermission = item, IdProfile = profile.Id };
                        if (obj.SelectedPermissionIdList != null)
                        {
                            if (!obj.SelectedPermissionIdList.Contains(item))
                            {
                                _accessService.Delete(deleteAccess);
                            }
                        }
                        else
                        {
                            _accessService.Delete(deleteAccess);
                        }
                    }
                    if (obj.SelectedPermissionIdList != null)
                    {
                        foreach (var item in obj.SelectedPermissionIdList)
                        {
                            if (!IdPermissions.Contains(item))
                            {
                                Access newAccess = new Access() { IdPermission = item, IdProfile = profile.Id };
                                _accessService.Insert(newAccess);
                                accessInserted.Add(newAccess);
                            }
                        }
                    }
                    SaveChanges();
                    Commit();
                }
            }
            catch (Exception e)
            {
                Rollback();
                errors.Add(CodLogErrorEnum.CODELOGERROR.ToString());           
            }
            return errors;
        }

        public List<PermissionViewModel> GetPermissions(int idProfile)
        {
            Expression<Func<Permission, bool>> filter = (Permission p) => p.Id == idProfile;
            var PermissionsMapped = AutoMapper.Mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionViewModel>>(_profileService.GetPermissions(idProfile));
            return PermissionsMapped.ToList();
        }
    }
}
