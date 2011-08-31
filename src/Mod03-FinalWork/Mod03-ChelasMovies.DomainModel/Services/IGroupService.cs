using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface IGroupService : IService<Group>
    {

        ICollection<Group> GetAllMyGroups(string user);

        void AddUserToGroup(int groupId, string username);
    }
}
