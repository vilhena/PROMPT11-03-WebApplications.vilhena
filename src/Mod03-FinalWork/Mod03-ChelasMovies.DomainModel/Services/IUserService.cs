using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface IUserService : IService<User>
    {
        User GetAuthenticatedUser(string username);
        ICollection<User> GetUsersFromGroup(int groupId);
    }
}
