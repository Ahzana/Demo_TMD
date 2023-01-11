using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TMDB_Movie_Search.Models;
using TMDB_Movie_Search.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TMDB_Movie_Search.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieApiService _movieApiService;

        public HomeController(IMovieApiService holidaysApiService)
        {
            _movieApiService = holidaysApiService;
        }
         
        public async Task<IActionResult> Index(string movieName) 
        {
            List<MovieModel> movies = new List<MovieModel>();

            if (!string.IsNullOrEmpty(movieName))
            {
                if (movieName.Length < 4)
                {
                    ViewData["ErrorMessage"] = "Movie Name must contain at least 4 characters!";
                }
                else
                {
                    movies = await _movieApiService.SearchMovies(movieName, 1);

                    if (movies.Count == 0)
                    {
                        ViewData["ErrorMessage"] = $"Sorry, no results found for \"{movieName}\"";
                    }
                }
            }

            return View(movies);
        }
    }
}
