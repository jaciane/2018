using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public  class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
           return  _repository.Get(filter, orderBy, includeProperties);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(T obj)
        {
            _repository.Insert(obj);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
