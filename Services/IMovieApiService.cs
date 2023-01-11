using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDB_Movie_Search.Models;
using TMDB_Movie_Search.Services;

namespace TMDB_Movie_Search.Services
{
    public interface IMovieApiService
    {
        Task<List<MovieModel>> SearchMovies(string movieName, int pageNumber);
    }
}
