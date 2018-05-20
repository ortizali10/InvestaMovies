using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestaMovies.Models
{
    /// <summary>
    /// Movie entity in repository.
    /// </summary>
    public class Movie
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public int YearReleased { get; set; }
        public string Rating { get; set; }
    }
}