﻿using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IComposedKeyGenericRepository<T> where T : class
    {
        T GetByComposedKey(int param1, int param2);
        void Delete(T obj);
    }
}
