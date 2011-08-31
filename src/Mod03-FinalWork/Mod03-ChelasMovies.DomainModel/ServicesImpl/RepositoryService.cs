using System;
using System.Collections.Generic;
using System.Linq;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public abstract class RepositoryService<T> : IService<T> where T : class 
    {
        protected readonly IRepository<T, int> _repository;

        public RepositoryService(IRepository<T,int> repository)
        {
            _repository = repository;
        }

        public virtual ICollection<T> GetAll()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual ICollection<T> Search(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            return _repository.GetAll(filterCriteria, pageIndex, pageSize, sortingCriteria);
        }

        public virtual T Get(int id)
        {
            return _repository.Get(id);
        }


        public virtual void Add(T entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public virtual void Update(T entity)
        {
            _repository.Save();
        }

        public virtual void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                _repository.Save();
            }
            catch (Exception e)
            {
                throw new ArgumentException(String.Format("id {0} could not be found", id), "id", e);
            }

        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}