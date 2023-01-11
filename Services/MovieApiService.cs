using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TMDB_Movie_Search.Models;

namespace TMDB_Movie_Search.Services
{
    public class MovieApiService : IMovieApiService
    {
        private readonly HttpClient client;

        public MovieApiService(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("SearchMovieApi");
        }

        public async Task<List<MovieModel>> SearchMovies(string movieName, int pageNumber = 1)
        {
            ResponseSearchMovie returnObject = new ResponseSearchMovie();
            List<MovieModel> movies = new List<MovieModel>();
            var response = await client.GetAsync($"search/movie?api_key=69b059740f38a8ed5e712d3bd111dcfb&language=en-US&query={movieName}&page={pageNumber}&include_adult=false");
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                returnObject = JsonSerializer.Deserialize<ResponseSearchMovie>(stringResponse,
                         new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            foreach (Result item in returnObject.results)
            {
                MovieModel movie = new MovieModel();
                movie.id=item.id;
                movie.posterPath = item.poster_path;
                movie.overview=item.overview;
                movie.title=item.title;
                movie.originalTitle = item.original_title;
                movie.year = !string.IsNullOrEmpty(item.release_date) ? Convert.ToDateTime(item.release_date).Year : 0;
                movie.voteAverage=item.vote_average;
                movie.voteCount=item.vote_count;
                movies.Add(movie);
            }

            return movies;
        }
    }
}
