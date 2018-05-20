using System;
using System.Collections.Generic;
using InvestaMovies.Helpers;
using InvestaMovies.Models;
using InvestaMovies.Repo;
using System.Net;
using System.Linq;
using AutoMapper;

namespace InvestaMovies.Services
{
    /// <summary>
    /// Service for executing queries to database.
    /// </summary>
    public class QueryService : IQueryService
    {
        protected readonly IRepository _repo;
        private readonly IMapper _mapper;
        public QueryService(IRepository repo)
        {
            _repo = repo;
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<UpdateMovieViewModel, Movie>();
                cfg.CreateMap<Movie, UpdateMovieViewModel>();
                cfg.CreateMap<MovieViewModel, Movie>();
                cfg.CreateMap<Movie, MovieViewModel>(); }).CreateMapper();;
        }

        public Result AddMovie(AddMovieViewModel model)
        {
            var result = new Result();
            try
            {
                var movie = new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = model.Title,
                    Rating = model.Rating,
                    YearReleased = model.YearReleased
                };

                _repo.Add(movie);
                _repo.Save();
                result.Message = "Succesfully added movie.";
                result.ResponseCode = HttpStatusCode.Created;
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Message = "Error saving movie: " + e.InnerException;
                result.ResponseCode = HttpStatusCode.InternalServerError;
                result.Success = false;
            }
            return result;
        }

        public Result DeleteMovie(string id)
        {
            var result = new Result();
            try
            {
                var movie = _repo.Get<Movie>(id);
                if (movie != null)
                {
                    _repo.Remove(movie);
                    _repo.Save();
                    result.Message = "Succesfully added movie.";
                    result.ResponseCode = HttpStatusCode.Created;
                    result.Success = true;
                    return result;
                }
                result.Message = "Movie not found";
                result.ResponseCode = HttpStatusCode.NotFound;
                result.Success = false;
            }
            catch
            {
                result.Message = "Error deleting movie";
                result.ResponseCode = HttpStatusCode.InternalServerError;
                result.Success = false;
            }
            return result;
        }

        public MovieViewModel GetMovie(string id)
        {
            var movie = new MovieViewModel();
            var result = _repo.Get<Movie>(id);
            
            return (result != null) ? movie = _mapper.Map<MovieViewModel>(result) : movie;
        }

        public List<MovieViewModel> GetMovies()
        {
            var movies = new List<MovieViewModel>();
            var result = _repo.Getall<Movie>();
            return (result != null) ? movies = _mapper.Map<List<MovieViewModel>>(result) : movies;
        }

        public Result UpdateMovie(UpdateMovieViewModel model)
        {
            var result = new Result();
            try
            {
                var movie = _repo.Get<Movie>(model.Id);

                if (movie != null)
                {
                    movie.Rating = model.Rating;
                    movie.Title = model.Title;
                    movie.YearReleased = model.YearReleased;
                    
                    _repo.Update(movie);
                    _repo.Save();
                    result.Message = "Movie successfully updated.";
                    result.ResponseCode = HttpStatusCode.OK;
                    result.Success = true;
                    return result;
                }
                result.Message = "Movie not found.";
                result.ResponseCode = HttpStatusCode.NotFound;
                result.Success = false;
            }
            catch (Exception e)
            {
                result.Message = "Error saving movie";
                result.ResponseCode = HttpStatusCode.InternalServerError;
                result.Success = false;
            }
            return result;
        }
    }
}