using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDB_Movie_Search.Models
{
    public class MovieModel
    {
        public int id { get; set; }
        public bool adult { get; set; }
        public List<int> genres { get; set; }
        public string originalTitle { get; set; }
        public int year { get; set; }
        public float voteAverage { get; set; }
        public int voteCount { get; set; }
        public string originalLanguage { get; set; }
        public string overview { get; set; }
        public string posterPath { get; set; }
        public string title { get; set; }
    }

    public class ResponseSearchMovie
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class Result
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }
}
