using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary
{
    

    static class Movielibrarian

    {
        private static MovieContext db = new MovieContext();
        public static MovieDetails CreateMovieDetails(string name, TypeOfLanguages language, double rating, int releasedYear, string availability)
        {
            var movieDetail = new MovieDetails();
            movieDetail.AddMovieDetails(name, language, rating, releasedYear, availability);
            db.MoviesDetails.Add(movieDetail);
            db.SaveChanges();
            return movieDetail;
            
        }

        public static void ChangeMovieDetails(int tracknumber, int views)
        {
            var movieDetails = db.MoviesDetails.SingleOrDefault(m => m.TrackNumber == tracknumber);
                if (movieDetails == null)
            {
                return;

            }
            movieDetails.ChangeViewsNumbers(views);

        }

        public static void RentMovie(string moviename,TypeOfLanguages language, int releaseyear )

        {
            var movieRental = new MovieRental
            {
                MovieName = moviename,
                Language = language,
                ReleasedYear = releaseyear,
                RentalType = TypesOfRental.Rent

            };

        }

        public static void BuyMovie(string moviename, string language, int releaseyear)

        {
            var movieRental = new MovieRental
            {
                MovieName = moviename,
                Language = Enum.Parse<TypeOfLanguages>(language),
                ReleasedYear = releaseyear,
                RentalType = TypesOfRental.Buy

            };

        }

    }
}
