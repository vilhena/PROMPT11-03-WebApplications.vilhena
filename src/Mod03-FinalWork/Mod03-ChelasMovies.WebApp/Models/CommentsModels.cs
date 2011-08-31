using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.WebApp.Models
{
    public class CommentsModel
    {
        [HiddenInput]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public String Description { get; set; }

        [Range(1, 5, ErrorMessage = "The rating must be between 1 and 5")]
        public Rating Rating { get; set; }

        public int MovieID { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}