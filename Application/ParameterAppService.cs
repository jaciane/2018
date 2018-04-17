using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces.Services;
using Data.Interfaces;

namespace Application
{
    public class ParameterAppService : GenericAppService, IParameterAppService
    {
        private readonly IGenericService<Parameter> _parameterAppService;
        private readonly IUnitOfWork _uow;

        public ParameterAppService(IGenericService<Parameter> parameterAppService, IUnitOfWork uow) : base(uow)
        {
            _parameterAppService = parameterAppService;
            _uow = uow;
        }

        public List<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParameterViewModel> Get(Expression<Func<ParameterViewModel, bool>> filter = null, Expression<Func<IQueryable<ParameterViewModel>, IOrderedQueryable<ParameterViewModel>>> orderBy = null, string includeProperties = "")
        {
            var filterNew = filter != null ? AutoMapper.Mapper.Map<Expression<Func<ParameterViewModel, bool>>, Expression<Func<Parameter, bool>>>(filter) : null;
            var orderByNew = orderBy != null ? AutoMapper.Mapper.Map<Expression<Func<IQueryable<ParameterViewModel>, IOrderedQueryable<ParameterViewModel>>>
                , Expression<Func<IQueryable<Parameter>, IOrderedQueryable<Parameter>>>>(orderBy) : null;
            return AutoMapper.Mapper.Map<IEnumerable<Parameter>, IEnumerable<ParameterViewModel>>(_parameterAppService.Get(filterNew, orderByNew, includeProperties));
        }

        public IEnumerable<ParameterViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ParameterViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ParameterViewModel GetParameterByName(string name)
        {
            Expression<Func<ParameterViewModel, bool>> filter =  (ParameterViewModel p) => p.Name.ToLower().Equals(name.ToLower());
            var result = this.Get(filter, orderBy: q => q.OrderBy(d => d.Name));
            return result.FirstOrDefault();
        }

        public Dictionary<string, string> GetParameterByType(string type)
        {
            Expression<Func<ParameterViewModel, bool>> filter = (ParameterViewModel p) => p.Type.ToLower().Equals(type.ToLower());
            var result = this.Get(filter, orderBy: q => q.OrderBy(d => d.Name));
            return result.ToDictionary(x => x.Name, x => x.Value);
        }

        public List<string> Insert(ParameterViewModel obj)
        {
            throw new NotImplementedException();
        }

        public List<string> Update(ParameterViewModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
