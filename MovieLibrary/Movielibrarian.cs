using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary
{
    

    static class Movielibrarian

    {
        private static List<MovieDetails> movies = new List<MovieDetails>();
        public static MovieDetails CreateMovieDetails(string name, TypeOfLanguage language, double rating, int releasedYear, string availability)
        {
            var movieDetail = new MovieDetails();
            movieDetail.AddMovieDetails(name, language, rating, releasedYear, availability);
            movies.Add(movieDetail);
            return movieDetail;
            
        }

        public static void ChangeMovieDetails(string name, int views)
        {
            var movieDetails = movies.SingleOrDefault(m => m.MovieName == name);
                if (movieDetails == null)
            {
                return;

            }
            var movie = new MovieDetails();
            movie.ChangeViewsNumbers(views);


        }

    }
}
