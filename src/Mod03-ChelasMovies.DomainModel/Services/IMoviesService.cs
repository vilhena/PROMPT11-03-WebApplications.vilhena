using System;
using System.Collections.Generic;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface IMoviesService : IService<Movie>
    {
        ICollection<Movie> GetAllMovies();
        Movie GetWithComments(int id);
        Movie Search(string title);
        void Fill(Movie movie);
        void DeleteComment(int movieId, int id);
    }
}