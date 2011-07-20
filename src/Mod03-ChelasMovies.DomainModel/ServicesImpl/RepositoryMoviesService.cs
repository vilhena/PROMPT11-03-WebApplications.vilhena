using System;
using System.Collections.Generic;
using System.Linq;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryMoviesService : RepositoryService<Movie>, IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly ICommentsService _commentsService;

        public RepositoryMoviesService(IMoviesRepository moviesRepository, ICommentsService commentsService)
            : base(moviesRepository)
        {
            _moviesRepository = moviesRepository;
            _commentsService = commentsService;
        }

        public ICollection<Movie> GetAllMovies()
        {
            return GetAll();
        }


        public Movie GetWithComments(int id)
        {
            return _moviesRepository.Get(id);
        }

        public Movie Search(string title)
        {
            return _moviesRepository.Search(title);
        }

        public void Fill(Movie movie)
        {
            var imdbMovie = Search(movie.Title);
            if (imdbMovie != null)
            {
                movie.Title = imdbMovie.Title;
                movie.Year = imdbMovie.Year;
                movie.Genre = imdbMovie.Genre;
                movie.Actors = imdbMovie.Actors;
                movie.Runtime = imdbMovie.Runtime;
                movie.Director = imdbMovie.Director;
                movie.Image = imdbMovie.Image;
            }
        }

        public void DeleteComment(int movieId, int id)
        {
            
            var movie =_moviesRepository.Get(movieId);
            var comment = movie.Comments.FirstOrDefault(c => c.ID == id);

            if (comment == null)
                throw new InvalidOperationException("");

            _commentsService.Delete(comment.ID);
            Update(movie);
        }

        public new void Dispose()
        {
            _moviesRepository.Dispose();
        }

    }
}