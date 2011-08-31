using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.RepImpl {
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;
    using Mod03_ChelasMovies.DomainModel.ServicesRepositoryImpl;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public class EFIACLsRepository : EFDbContextRepository<ACL, int>, IACLsRepository
    {
        public EFIACLsRepository(MovieDbContext aclContext) : base(aclContext) { }
    }
}