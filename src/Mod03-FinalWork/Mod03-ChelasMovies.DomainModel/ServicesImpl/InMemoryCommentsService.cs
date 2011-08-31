using System;
using System.Collections.Generic;
using Mod03_ChelasMovies.DomainModel.Services;
using System.Linq;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    using System.Threading;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public class InMemoryCommentsService : ICommentsService
    {
        static List<Comment> acls;

        static int newId;


        static InMemoryCommentsService()
        {

        }




        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        public ICollection<Comment> GetAllComments(int movieId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> Search(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public ICollection<Comment> GetForWall(string username, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}