using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_2._0.Models
{
    public class Genre
    {
        public byte id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }
}