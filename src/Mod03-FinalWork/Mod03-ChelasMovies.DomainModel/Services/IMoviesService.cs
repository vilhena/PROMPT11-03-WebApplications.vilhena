using System;
using System.Collections.Generic;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.DomainModel.Views;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface IMoviesService : IService<Movie>
    {
        ICollection<Movie> GetAllMovies();
        Movie GetWithComments(int id);
        Movie Search(string title);
        void Fill(Movie movie);
        void DeleteComment(int movieId, int id);
        ICollection<Movie> GetMyMovies(string username);

        ICollection<Movie> GetForWall(string username, int pageIndex, int pageSize);
    }
}