﻿using Data.Interfaces;

namespace Application
{
    public class GenericAppService
    {
        private readonly IUnitOfWork _uow;

        public GenericAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }
       public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }
        public void Commit()
        {
            _uow.Commit();
        }

        public void Rollback()
        {
            _uow.Rollback();
        }

        public void SaveChanges()
        {
            _uow.SaveChanges();
        }

    }
}
