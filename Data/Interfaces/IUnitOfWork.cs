using Data.Repositories;
using System;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit(bool dispose = true);
        void SaveChanges();
        void Rollback(bool dispose = true);
    }
}
