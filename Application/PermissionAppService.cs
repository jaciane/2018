using Application.Interfaces;
using Data.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using System.Linq.Expressions;
using Domain.Entities;

namespace Application
{
    public class PermissionAppService : GenericAppService, IPermissionAppService
    {
        private readonly IPermissionService _permissionService;
        private readonly IUnitOfWork _uow;

        public PermissionAppService(IPermissionService permissionService, IUnitOfWork uow) : base(uow)
        {
            _permissionService = permissionService;
            _uow = uow;
        }

        public List<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PermissionViewModel> Get(Expression<Func<PermissionViewModel, bool>> filter = null, Expression<Func<IQueryable<PermissionViewModel>, IOrderedQueryable<PermissionViewModel>>> orderBy = null, string includeProperties = "")
        {
            var filterNew = filter != null ? AutoMapper.Mapper.Map<Expression<Func<PermissionViewModel, bool>>, Expression<Func<Permission, bool>>>(filter) : null;
            var orderByNew = orderBy != null ? AutoMapper.Mapper.Map<Expression<Func<IQueryable<PermissionViewModel>, IOrderedQueryable<PermissionViewModel>>>
                , Expression<Func<IQueryable<Permission>, IOrderedQueryable<Permission>>>>(orderBy) : null;
            return AutoMapper.Mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionViewModel>>(_permissionService.Get(filterNew, orderByNew, includeProperties));
        }

        public IEnumerable<PermissionViewModel> GetAll()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionViewModel>>(_permissionService.GetAll());
        }

        public PermissionViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> Insert(PermissionViewModel obj)
        {
            throw new NotImplementedException();
        }

        public List<string> Update(PermissionViewModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
