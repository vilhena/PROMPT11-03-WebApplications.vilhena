namespace Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces {
    using System.Collections.Generic;
    using Rep;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public interface IUsersRepository : IRepository<User, int> {
    }
}