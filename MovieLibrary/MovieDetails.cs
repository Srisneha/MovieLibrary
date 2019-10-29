using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    /// <summary>
    /// This is a Movie Library where the user can view and get the movie details to watch it in Netflix, Prime etc
    /// where the Librarian can add the details
    /// And user can only have view access to view the details
    /// </summary>
    /// 
    enum TypeOfLanguages
    {
        English,
        Tamil,
        Telegu,
        Kanada,
        Malayalam,
        Hindi
    }
    class MovieDetails
    {
        #region Properties
        public string MovieName { get;  private set; }
        public int ReleasedYear { get;  private set;}
        public DateTime CreatedDate { get; private set; }

        public int TrackNumber { get; private set; }

        public TypeOfLanguages Language { get; private set; }

        public double Rating { get;  private set; }
        public string Availability { get;  private set; }

        public  static int  lastTrackNumber = 0;

        public static int Views { get; private set; }

        #endregion

        #region Constructor

        public MovieDetails()
        {
            TrackNumber = ++lastTrackNumber;
            CreatedDate = DateTime.Now;
            Views = 0;
           
        }
        #endregion

        #region Methods

        public void AddMovieDetails(string name,TypeOfLanguages language, double rating,int releasedYear, string availability)
        {
            MovieName = name;
            Language = language;
            Rating = rating;
            ReleasedYear = releasedYear;
            Availability = availability;
            
        }

      
        public void ChangeViewsNumbers(int views)
        {
            Views = views;
        }


        #endregion
    }
}
