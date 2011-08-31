using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.DomainModel.Views;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface IWallService
    {
        ICollection<WallItem> GetMyWall(string username);
    }
}
