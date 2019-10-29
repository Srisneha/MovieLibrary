using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    enum TypesOfRental
    {
       OneTime,
       AnyTime
    }
    class MovieRental
    {
        public int RentalID { get; set; }
        public string MovieName { get; set; }
        public TypeOfLanguages Language { get; set; }

        public int ReleasedYear { get; set; }
        public TypesOfRental RentalType { get; set; }
        public int TrackNumber { get; set; }
        public virtual MovieDetails MovieDetails { get; set; }
    }
}
