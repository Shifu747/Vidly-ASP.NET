using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_2._0.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }
        public DateTime DateAded { get; set; }


        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }

    }
}