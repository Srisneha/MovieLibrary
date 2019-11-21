using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary
{
    

    public static class Movielibrarian

    {
        private static MovieContext db = new MovieContext();
        public static MovieDetails CreateMovieDetails(string name, TypeOfLanguages language, int releasedYear,string availability, double rating)
        {
            var movieDetail = new MovieDetails();
            movieDetail.AddMovieDetails(name, language, rating, releasedYear, availability);
            db.MoviesDetails.Add(movieDetail);
            db.SaveChanges();
            return movieDetail;
            
        }

        public static IEnumerable<MovieDetails> GetAllMoviesByLanguage(TypeOfLanguages language)
        {
            return db.MoviesDetails.Where(m => m.Language == language)
                .OrderBy(m => m.ReleasedYear);
        }

        public static IEnumerable<MovieRental> GetAllMoviesByRentalType(TypesOfRental rentalType)
        {
            return db.MoviesRental.Where(r => r.RentalType == rentalType);

        }

        public static MovieDetails GetMovieDetailsByTrackNumber(int trackNumber)
        {
           return db.MoviesDetails.Find(trackNumber);
        }
       
        public static void UpdateMovieDetails(MovieDetails updatedmovieDetails)
        {
            var oldMovie  = GetMovieDetailsByTrackNumber(updatedmovieDetails.TrackNumber);
            oldMovie.Rating = updatedmovieDetails.Rating;
            oldMovie.Views = updatedmovieDetails.Views;
            oldMovie.Availability = updatedmovieDetails.Availability;
            db.SaveChanges();

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
            db.MoviesRental.Add(movieRental);
            db.SaveChanges();
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

            db.MoviesRental.Add(movieRental);
            db.SaveChanges();
        }

    }
}
