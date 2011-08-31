using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.DomainModel.Views
{
    public class WallItem
    {
        public string UserNickname { get; set; }
        public DateTime Updated { get; set; }
        public DomainBase EntityChanged { get; set; }
    }
}
