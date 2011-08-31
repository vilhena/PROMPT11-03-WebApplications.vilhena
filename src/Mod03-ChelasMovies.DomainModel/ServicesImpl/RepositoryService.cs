using System;
using System.Collections.Generic;
using System.Linq;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryService<T> : IService<T> where T : class 
    {
        private readonly IRepository<T, int> _repository;

        public RepositoryService(IRepository<T,int> repository)
        {
            _repository = repository;
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll().ToList();
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