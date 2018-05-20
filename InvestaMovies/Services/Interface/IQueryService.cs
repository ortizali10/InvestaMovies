using InvestaMovies.Helpers;
using InvestaMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestaMovies.Services
{
    /// <summary>
    /// Interface for query service. TO DO : change server calls to async
    /// </summary>
    public interface IQueryService
    {
        List<MovieViewModel> GetMovies();
        MovieViewModel GetMovie(string id);
        Result AddMovie(AddMovieViewModel model);
        Result UpdateMovie(UpdateMovieViewModel model);
        Result DeleteMovie(string id);
    }
}