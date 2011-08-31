using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod03_ChelasMovies.DomainModel.Domain
{
    public class DomainBase
    {
        public DomainBase()
        {
            LastUpdated = DateTime.Now;
        }
        public DateTime LastUpdated { get; set; }
    }
}
