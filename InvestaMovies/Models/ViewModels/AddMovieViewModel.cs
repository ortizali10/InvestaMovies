using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InvestaMovies.Models
{
    /// <summary>
    /// ViewModel/DTO for adding movie
    /// </summary>
    public class AddMovieViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        //[Range(1800, 2100)]
        public int YearReleased { get; set; }
        [Required]
        public string Rating { get; set; }
    }
}