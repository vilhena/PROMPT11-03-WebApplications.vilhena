using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mod03_ChelasMovies.DomainModel.Domain
{
    public class ACL : DomainBase
    {
        [HiddenInput]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        public bool Read { get; set; }
        public bool Change { get; set; }
        public bool Delete { get; set; }
    }
}
