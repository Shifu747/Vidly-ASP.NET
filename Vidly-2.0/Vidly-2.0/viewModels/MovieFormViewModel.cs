using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2._0.Models;

namespace Vidly_2._0.viewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}