using Mod03_ChelasMovies.Rep;

namespace Mod03_ChelasMovies.RepImpl {
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;

    public class EFIRepository<T, TKey> : EFDbContextRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        public EFIRepository(DbContext<T> context) : base(context) { }
    }
}