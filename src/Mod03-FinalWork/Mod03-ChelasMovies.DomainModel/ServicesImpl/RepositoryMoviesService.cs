using System;
using System.Collections.Generic;
using System.Linq;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryMoviesService : RepositoryService<Movie>, IMoviesService
    {
        private readonly ICommentsService _commentsService;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IACLService _aclService;

        public RepositoryMoviesService(IMoviesRepository moviesRepository, ICommentsService commentsService, IACLService aclService)
            : base(moviesRepository)
        {
            _moviesRepository = moviesRepository;
            _commentsService = commentsService;
            _aclService = aclService;
        }

        public ICollection<Movie> GetAllMovies()
        {
            return GetAll();
        }


        public Movie GetWithComments(int id)
        {
            var movie = _moviesRepository.Get(id);
            movie.Comments = _commentsService.GetAllComments(id);
            return movie;
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

            var movie = _moviesRepository.Get(movieId);
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



        public ICollection<Movie> GetMyMovies(string username)
        {
            return _moviesRepository.GetAll().Where(m => m.Owner.Username == username).ToList();
        }


        public ICollection<Movie> GetForWall(string username, int pageIndex, int pageSize)
        {
            var moviesList = _moviesRepository.GetAll().Where(m => m.Owner.Username == username)
                .OrderByDescending(m=>m.LastUpdated)
                .Take(pageSize).Skip(pageIndex).ToList();

            var friends = _aclService.GetAllUsersThatAllowsRead(username);

            moviesList.AddRange(_moviesRepository.GetAll().ToList()
                .Where(m => friends.Contains(m.Owner)).ToList());

            return moviesList;
        }
    }
}