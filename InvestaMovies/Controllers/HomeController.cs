using InvestaMovies.Helpers;
using InvestaMovies.Models;
using InvestaMovies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestaMovies.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IQueryService _queryService; // Implement single instance of query service
        public HomeController(IQueryService queryService)
        {
            _queryService = queryService; // dependency injection
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return PartialView("_AddMovie");
        }

        [HttpGet] // proper api route: (HttpGet) api/movies/{id}
        public ActionResult UpdateMovie(string id)
        {
            var model = new UpdateMovieViewModel();
            var result = _queryService.GetMovie(id);
            model.Rating = result.Rating;
            model.Title = result.Title;
            model.YearReleased = result.YearReleased;
            model.Id = result.Id;

            return PartialView("_UpdateMovie", model);
        }
        
        [HttpDelete] // proper api route: (HttpDelete) api/movies/{id}
        public ActionResult DeleteMovie(string id)
        {
            var response = new Result();
            return (ModelState.IsValid) ? Json(response = _queryService.DeleteMovie(id)) : Json(response);
        }

        [HttpPost] // proper api route: (HttpGet) api/movies/
        public ActionResult GetMovies()
        {
            var test = _queryService.GetMovies();
            return Json(test);
        }

        [HttpPost] // proper api route: (HttpGet) api/movies/{id}
        public ActionResult GetMovieById(string id)
        {
            var response = _queryService.GetMovie(id);
            return Json(response);
        }

        [HttpPost] // proper api route: (HttpPost) api/movies/ - values in request body
        public ActionResult AddMovie(AddMovieViewModel model)
        {
            var response = new Result();
            if (ModelState.IsValid)
            {
                return Json(response = _queryService.AddMovie(model));
            }
            return PartialView("_AddMovie", model);
        }

        [HttpPost] // proper api route: (HttpPut) api/movies/ - values in request body
        public ActionResult UpdateMovie(UpdateMovieViewModel model)
        {
            var response = new Result();
            return (ModelState.IsValid) ? Json(response = _queryService.UpdateMovie(model)) : Json(response);
        }
    }
}