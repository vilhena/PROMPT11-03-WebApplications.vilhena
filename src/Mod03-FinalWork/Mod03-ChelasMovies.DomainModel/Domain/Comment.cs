using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mod03_ChelasMovies.DomainModel.Domain
{
    public enum Rating
    {
        Ratinng1 = 1, 
        Ratinng2, 
        Ratinng3, 
        Ratinng4, 
        Ratinng5
    }

    public class Comment : DomainBase
    {
        [HiddenInput]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public String Description { get; set; }

        [Range(1, 5, ErrorMessage = "The rating must be between 1 and 5")]
        public Rating Rating { get; set; }

        //public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public User Owner { get; set; }
        
    }
}