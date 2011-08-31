using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mod03_ChelasMovies.DomainModel.Domain
{
    public class User : DomainBase
    {
        public User()
        {
            BelongsToGroups = new List<Group>();
        }

        [HiddenInput]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NickName { get; set; }

        public ICollection<Group> BelongsToGroups { get; set; }
    }
}
