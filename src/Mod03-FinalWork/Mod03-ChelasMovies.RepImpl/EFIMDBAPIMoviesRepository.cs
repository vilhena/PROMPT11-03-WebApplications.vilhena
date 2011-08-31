using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.RepImpl {
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;
    using Mod03_ChelasMovies.DomainModel.Domain;
    using Mod03_ChelasMovies.DomainModel.ServicesRepositoryImpl;

    public class EFIMDBAPIMoviesRepository : EFDbContextRepository<Movie, int>, IMoviesRepository
    {
        public EFIMDBAPIMoviesRepository(MovieDbContext moviesContext) : base(moviesContext) { }

        public Movie Search(string title)
        {
            return TheIMDbAPI.SearchByTitle(title);
        }
    }
}