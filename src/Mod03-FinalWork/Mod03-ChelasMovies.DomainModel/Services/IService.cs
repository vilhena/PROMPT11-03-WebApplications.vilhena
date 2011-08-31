using System;
using System.Collections.Generic;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface IService<T> : IDisposable
    {
        ICollection<T> GetAll();
        ICollection<T> Search(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria);
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}