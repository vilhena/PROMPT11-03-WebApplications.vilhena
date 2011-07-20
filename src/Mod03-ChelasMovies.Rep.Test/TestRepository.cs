using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel;
using Mod03_ChelasMovies.RepImpl;
using NUnit.Framework;

namespace Mod03_ChelasMovies.Rep.Test
{
    [TestFixture]
    public class TestRepository
    {
        [Test]
        public void ShouldDeleteCommentFromMovies()
        {
            MovieDbContext context = new MovieDbContext();
            EFIMDBAPIMoviesRepository repository = new EFIMDBAPIMoviesRepository(context);

            EFICommentsRepository repositoryC = new EFICommentsRepository(context);


            var movie = repository.Get(4);
            var comment = movie.Comments.First();

            movie.Comments.Remove(comment);
            comment.Movie = null;
            repositoryC.Delete(comment.ID);
            repositoryC.Save();

            repository.Save();
        }
    }
}
