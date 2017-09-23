using Microsoft.AspNetCore.Mvc;
using MovieRecommender.Core.Interfaces;
using MovieRecommender.Web.Models;
using System.Diagnostics;

namespace MovieRecommender.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovieService _movieService;

        public MovieController(IUnitOfWork unitOfWork, IMovieService movieService)
        {
            _unitOfWork = unitOfWork;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetRecommendedMovies(int[] preferredMovieIds)
        {
            var recommendedMovies = _movieService.GetRecommendedMovies(preferredMovieIds);

            return Ok(recommendedMovies);
        }

        [HttpGet]
        public IActionResult GetMovies(string query)
        {
            var movies = _unitOfWork.MovieRepository.Search(query);

            return Ok(movies);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}