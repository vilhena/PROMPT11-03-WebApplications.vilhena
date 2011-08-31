using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.DomainModel.Services;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryACLService: RepositoryService<ACL>, IACLService
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        public RepositoryACLService(IACLsRepository repository, IGroupService groupService, IUserService userService)
            : base(repository)
        {
            _groupService = groupService;
            _userService = userService;
        }

        public IList<User> GetAllUsersThatAllowsRead(string username)
        {
            return _groupService.GetAll().Where(g => g.Users
                .Contains(_userService.GetAuthenticatedUser(username)) && g.Permissions.Read == true)
                .Select(g=>g.Owner).ToList();
            
        }
    }
}
