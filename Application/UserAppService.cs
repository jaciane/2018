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
        List<string> errors = new List<string>();

        public UserAppService(IUserService userService, IUnitOfWork uow) : base(uow)
        {
            _userService = userService;
            _uow = uow;
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
            try
            {
                BeginTransaction();
                User user = _userService.GetById(id);
                errors = _userService.Delete(user);
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

        public List<string> UpdateProfile(UserViewModel obj)
        {           
            try
            {
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
            }
            return errors;
        }
    }
}
