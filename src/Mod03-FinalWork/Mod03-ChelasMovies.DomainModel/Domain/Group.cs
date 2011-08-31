using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mod03_ChelasMovies.DomainModel.Domain
{
    public class Group : DomainBase
    {
        public Group()
        {
            Users = new List<User>();
        }

        [HiddenInput]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [HiddenInput]
        public virtual User Owner { get; set; }

        public virtual ACL Permissions { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
