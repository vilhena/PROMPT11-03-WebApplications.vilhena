using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryCommentsService:ICommentsService 
    {
        private readonly ICommentsRepository _commentsRepository;

        public RepositoryCommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public void Dispose()
        {
            _commentsRepository.Dispose();
        }

        public ICollection<Comment> GetAllComments(int movieId)
        {
            return _commentsRepository.GetAll().Where(c => c.Movie.ID == movieId).ToList();
        }

        public ICollection<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            return _commentsRepository.Get(id);
        }

        public void Add(Comment newComment)
        {
            _commentsRepository.Add(newComment);
        }

        public void Update(Comment comment)
        {
            _commentsRepository.Update(comment);
        }

        public void Delete(int id)
        {
            _commentsRepository.Delete(id);
        }
    }
}
