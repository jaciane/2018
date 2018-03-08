using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application
{
    public class LogErrorAppService : GenericAppService, ILogErrorAppService
    {
        private readonly IGenericService<LogError> _logErrorService;
        private readonly IUnitOfWork _uow;

        public LogErrorAppService(IGenericService<LogError> logErrorService, IUnitOfWork uow) : base(uow)
        {
            _logErrorService = logErrorService;
            _uow = uow;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogError> Get(Expression<Func<LogError, bool>> filter = null, Func<IQueryable<LogError>, IOrderedQueryable<LogError>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogError> GetAll()
        {
            throw new NotImplementedException();
        }

        public LogError GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(LogError obj)
        {
            BeginTransaction();
            _logErrorService.Insert(obj);
            Commit();
        }

        public void Update(LogError obj)
        {
            throw new NotImplementedException();
        }
    }
}
