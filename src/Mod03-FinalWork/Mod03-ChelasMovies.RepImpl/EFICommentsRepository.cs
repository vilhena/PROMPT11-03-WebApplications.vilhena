using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.RepImpl {
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;
    using Mod03_ChelasMovies.DomainModel.ServicesRepositoryImpl;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public class EFICommentsRepository : EFDbContextRepository<Comment, int>, ICommentsRepository
    {
        public EFICommentsRepository(MovieDbContext moviesContext) : base(moviesContext) { }
    }
}