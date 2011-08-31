using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.DomainModel.Services;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryUserService: RepositoryService<User>, IUserService
    {
        public RepositoryUserService(IUsersRepository repository)
            :base(repository)
        {
        }

        /// <summary>
        /// Gets the user for the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>it returns null if </returns>
        public User GetAuthenticatedUser(string username)
        {
            var user = _repository.GetAll().Where(u => u.Username == username).FirstOrDefault();
            if (user == null)
                throw new NotImplementedException("User does not Exists");
            return user;
        }


        public ICollection<User> GetUsersFromGroup(int groupId)
        {
            return _repository.GetAll().Where(u => u.BelongsToGroups.Select(g => g.ID).Contains(groupId)).ToList();
        }
    }
}
