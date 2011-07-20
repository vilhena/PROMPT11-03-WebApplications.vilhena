using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.RepImpl {
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;

    public class EFICommentsRepository : EFDbContextRepository<Comment, int>, ICommentsRepository
    {
        public EFICommentsRepository(MovieDbContext moviesContext) : base(moviesContext) { }
    }
}