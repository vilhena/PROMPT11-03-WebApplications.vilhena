using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface IACLService: IService<ACL>
    {
        IList<User> GetAllUsersThatAllowsRead(string username);
    }
}
