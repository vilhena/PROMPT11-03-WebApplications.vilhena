using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.DomainModel.Services;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryGroupService : RepositoryService<Group>, IGroupService
    {
        private readonly IUserService _userService;

        public RepositoryGroupService(IGroupsRepository repository, IUserService userService)
            : base(repository)
        {
            _userService = userService;
        }

        public ICollection<Group> GetAllMyGroups(string user)
        {

            var myGroups = _repository.GetAll().Where(g => g.Owner.Username == user);
            foreach (var group in myGroups)
            {
                group.Users = _userService.GetUsersFromGroup(group.ID);
            }

            return myGroups.ToList();
        }


        public void AddUserToGroup(int groupId, string username)
        {
            //TODO: Check if exists
            var targetUser = _userService.GetAuthenticatedUser(username);
            var currentGroup = _repository.Get(groupId);

            if (currentGroup.Users.Contains(targetUser))
                throw new NotImplementedException("Must Throw Exception existing user");

            currentGroup.Users.Add(targetUser);
            _repository.Save();
        }
    }
}
