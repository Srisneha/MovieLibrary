using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary
{
    

    public static class Movielibrarian

    {
        private static MovieContext db = new MovieContext();
        public static MovieDetails CreateMovieDetails(string name, TypeOfLanguages language, int releasedYear,string availability, double rating,double buyamount, double rentamount)
        {
            var movieDetail = new MovieDetails();
            movieDetail.AddMovieDetails(name, language, rating, releasedYear, availability,buyamount,rentamount);
            db.MoviesDetails.Add(movieDetail);
            db.SaveChanges();
            return movieDetail;
            
        }

        public static IEnumerable<MovieDetails> GetAllMoviesByLanguage(TypeOfLanguages language)
        {
            return db.MoviesDetails.Where(m => m.Language == language)
                .OrderBy(m => m.ReleasedYear);
        }

        public static IEnumerable<MovieRental> GetAllMoviesByRentalType(TypesOfRental rentalType, TypeOfLanguages languages)
        {
            return db.MoviesRental.Where(r => r.RentalType == rentalType && r.Language == languages);

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
        public static void RentMovie(int trackNumber)

        {
            var movie = db.MoviesDetails.SingleOrDefault(m => m.TrackNumber == trackNumber);
            if(movie == null)
            {
                //throw exception
                return;
            }

  

            var movieRental = new MovieRental
            {
                MovieName = movie.MovieName,
                Language = movie.Language,
                ReleasedYear = movie.ReleasedYear,
                RentalType = TypesOfRental.Rent,
                Amount = movie.RentAmount,
                TrackNumber = trackNumber
            };
            db.MoviesRental.Add(movieRental);
            db.SaveChanges();
        }

        public static void BuyMovie(int trackNumber)

        {
            var movie = db.MoviesDetails.SingleOrDefault(m => m.TrackNumber == trackNumber);
            if (movie == null)
            {
                throw new ArgumentNullException();
                
            }


            var movieRental = new MovieRental
            {
                MovieName = movie.MovieName,
                Language = movie.Language,
                ReleasedYear = movie.ReleasedYear,
                RentalType = TypesOfRental.Buy,
                Amount = movie.BuyAmount,
                TrackNumber = trackNumber

            };
            db.MoviesRental.Add(movieRental);
            db.SaveChanges();
        }

    }
}
