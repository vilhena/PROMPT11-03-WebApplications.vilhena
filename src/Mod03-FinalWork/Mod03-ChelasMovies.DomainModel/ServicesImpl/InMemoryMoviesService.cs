using System;
using System.Collections.Generic;
using Mod03_ChelasMovies.DomainModel.Services;
using System.Linq;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    using System.Threading;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public class InMemoryMoviesService : IMoviesService
    {
        static List<Movie> movies;
        static List<Comment> comments;

        static int newId;


        static InMemoryMoviesService()
        {
            var userService = new InMemoryUsersService();

            movies = new List<Movie>
                             {

                                 new Movie
                                     {
                                         ID = 1,
                                         Title = "When Harry Met Sally1",
                                         Genre = "Romantic Comedy",
                                         Year = 2004,
                                         Image = @"http://ia.media-imdb.com/images/M/MV5BOTYzNzM3NDA4MV5BMl5BanBnXkFtZTcwMjU1NDkxMQ@@._V1._SX320.jpg",
                                         Comments = new List<Comment>(),
                                         Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                     },

                                 new Movie
                                     {
                                         ID = 2,
                                         Title = "Ghostbusters 2",
                                         Genre = "Comedy",
                                         Year = 2002,
                                         Comments = new List<Comment>(),
                                         Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                     },
                                 new Movie
                                     {
                                         ID = 3,
                                         Title = "Ninja das Caldas",
                                         Genre = "Comedy",
                                         Year = 2000,
                                         Comments = new List<Comment>(),
                                         Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                     },
                                 new Movie
                                     {
                                         ID = 4,
                                         Title = "Batman",
                                         Genre = "Action",
                                         Year = 2000,
                                         Image = @"http://ia.media-imdb.com/images/M/MV5BMjExNjMzMTUxNV5BMl5BanBnXkFtZTYwNzQyMTg4._V1._SX320.jpg",
                                         Comments = new List<Comment>(),
                                         Owner = userService.GetAll().Where(u=>u.Username == "kalavera").First(),
                                     },
                                 new Movie
                                     {
                                         ID = 5,
                                         Title = "There's Something About Mary",
                                         Genre = "Comedy",
                                         Year = 2000,
                                         Image = @"http://ia.media-imdb.com/images/M/MV5BMjA0OTU2MzYwOV5BMl5BanBnXkFtZTYwNTA3OTk5._V1._SX320.jpg",
                                         Comments = new List<Comment>(),
                                         Owner = userService.GetAll().Where(u=>u.Username == "kalavera").First(),
                                     },
                                 new Movie
                                     {
                                         ID = 6,
                                         Title = "Hangover",
                                         Genre = "Comedy",
                                         Year = 2000,
                                         Image = @"http://ia.media-imdb.com/images/M/MV5BMTU1MDA1MTYwMF5BMl5BanBnXkFtZTcwMDcxMzA1Mg@@._V1._SX320.jpg",
                                         Comments = new List<Comment>(),
                                         Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                     },


                             };

        comments = new List<Comment>
                               {
                                   new Comment
                                       {
                                           Description = "Description 1",
                                           Rating = Rating.Ratinng3,
                                           Movie = movies[0],
                                           Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                       },
                                   new Comment
                                       {
                                           Description = "Description 2",
                                           Rating = Rating.Ratinng4,
                                           Movie = movies[0],
                                           Owner = userService.GetAll().Where(u=>u.Username == "kalavera").First(),
                                       },

                                   new Comment
                                       {
                                           Description = "Description 3",
                                           Rating = Rating.Ratinng5,
                                           Movie = movies[1],
                                           Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                       },
                                       new Comment
                                       {
                                           Description = "Description 4",
                                           Rating = Rating.Ratinng4,
                                           Movie = movies[1],
                                           Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                       },

                               };

        newId = movies.Count;

        }

        public ICollection<Movie> GetAllMovies()
        {
            return movies;
        }

        public ICollection<Movie> GetAll()
        {
            return movies;
        }

        public Movie Get(int id)
        {
            foreach (Movie m in movies) {
                if (m.ID == id) return m;
            }
            return null;
        }

        public Movie GetWithComments(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Movie newMovie)
        {
            newMovie.ID = Interlocked.Increment(ref newId);
            movies.Add(newMovie);
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movie Search(string title)
        {
            throw new NotImplementedException();
        }

        public ICollection<Movie> Search(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            //Dummy filtering
            return GetAll();
        }

        public void Fill(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void FillWithIMDB(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int movieId, int id)
        {
            throw new NotImplementedException();
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


        public ICollection<Movie> GetMyMovies(string username)
        {
            throw new NotImplementedException();
        }


        public ICollection<Movie> GetForWall(string username, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}