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

        public ICollection<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }


        public void Add(T entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Update(T entity)
        {
            _repository.Save();
        }

        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                _repository.Save();
            }
            catch (Exception e)
            {
                throw new ArgumentException(String.Format("Movie with id {0} could not be found", id), "id", e);
            }

        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}