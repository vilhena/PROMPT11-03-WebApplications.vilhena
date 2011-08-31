using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.WebApp.Models
{
    public class GroupCreateModel
    {
        [Required]
        [StringLength(64)]
        public String Name { get; set; }

        public bool Read { get; set; }
        public bool Change { get; set; }
        public bool Delete { get; set; }
    }

    public class GroupAddUserModel
    {
        [HiddenInput]
        public int GroupID { get; set; }

        [Required]
        public String Username { get; set; }
    }

    public class GroupDevailsModel
    {
        [HiddenInput]
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public String Name { get; set; }

        public bool Read { get; set; }
        public bool Change { get; set; }
        public bool Delete { get; set; }
    }
}