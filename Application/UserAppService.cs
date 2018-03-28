using Application.Interfaces;
using Data.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.ViewModels;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Util;
using Domain.Enum;
using System.Web;

namespace Application
{
    public class UserAppService : GenericAppService, IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;
        private readonly IAuditAppService _auditAppService;
        private readonly ILogErrorAppService _logErrorAppService;

        public UserAppService(IUserService userService, IUnitOfWork uow,
            IAuditAppService auditAppService, ILogErrorAppService logErrorAppService) : base(uow)
        {
            _userService = userService;
            _uow = uow;
            _auditAppService = auditAppService;
            _logErrorAppService = logErrorAppService;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userService.GetAll()).OrderBy(q => q.Name);
        }

        public UserViewModel GetById(int id)
        {
            return AutoMapper.Mapper.Map<User, UserViewModel>(_userService.GetById(id));
        }

        public IEnumerable<UserViewModel> Get(Expression<Func<UserViewModel, bool>> filter = null, Expression<Func<IQueryable<UserViewModel>, IOrderedQueryable<UserViewModel>>> orderBy = null, string includeProperties = "")
        {
            var filterNew = filter != null ? AutoMapper.Mapper.Map<Expression<Func<UserViewModel, bool>>, Expression<Func<User, bool>>>(filter) : null;
            var orderByNew = orderBy != null ? AutoMapper.Mapper.Map<Expression<Func<IQueryable<UserViewModel>, IOrderedQueryable<UserViewModel>>>
                , Expression<Func<IQueryable<User>, IOrderedQueryable<User>>>>(orderBy) : null;
            return AutoMapper.Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_userService.Get(filterNew, orderByNew, includeProperties));
        }

        public List<string> Insert(UserViewModel obj)
        {
            throw new NotImplementedException();
        }

        public List<string> Update(UserViewModel obj)
        {
            throw new NotImplementedException();
        }

        public List<string> Delete(int id)
        {
            List<string> errors = new List<string>();
            try
            {
                _auditAppService.SetAuditPrimaryData();
                BeginTransaction();
                User user = _userService.GetById(id);
                errors = _userService.Delete(user);
                if (errors?.Count == 0)
                {
                    SaveChanges();
                    Audit(user, EnumDescription.GetEnumDescription(DomainMethodEnum.UPDATE));
                    Commit();
                }
            }
            catch (Exception e)
            {
                Rollback();
                errors.Add(CodLogErrorEnum.CODELOGERROR.ToString());
                _logErrorAppService.Insert(new LogErrorViewModel
                {
                    Controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString(),
                    Action = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Description = e.Message,
                    StackTrace = e.StackTrace,
                    User = HttpContext.Current.User.Identity.Name
                });
            }
            return errors;
        }

        public List<string> UpdateProfile(UserViewModel obj)
        {
            List<string> errors = new List<string>();
            try
            {
                _auditAppService.SetAuditPrimaryData();
                BeginTransaction();
                User user = AutoMapper.Mapper.Map<UserViewModel, User>(obj);
                errors = _userService.UpdateProfile(user);
                if (errors?.Count() == 0)
                {
                    SaveChanges();
                    Commit();
                }
            }
            catch (Exception e)
            {
                Rollback();
                errors.Add(CodLogErrorEnum.CODELOGERROR.ToString());
                _logErrorAppService.Insert(new LogErrorViewModel
                {
                    Controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString(),
                    Action = System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Description = e.Message,
                    StackTrace = e.StackTrace,
                    User = HttpContext.Current.User.Identity.Name
                });
            }
            return errors;
        }

        public void Audit(object obj, string method)
        {
            _auditAppService.SaveAudit(obj, method);
        }
    }
}
