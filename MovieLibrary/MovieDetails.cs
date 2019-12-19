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
    public enum TypeOfLanguages
    {
        
        Tamil =1,
        Telegu,
        Malayalam = 4,
        Hindi
    }
    public class MovieDetails
    {
        #region Properties
        public string MovieName { get;   set; }
        public int ReleasedYear { get;   set;}
        public DateTime CreatedDate { get;  set; }

        public int TrackNumber { get; set; }

        public TypeOfLanguages Language { get;  set; }

        public double Rating { get;   set; }

        public double RentAmount { get; set; }

        public double BuyAmount { get; set; }
        public string Availability { get;   set; }


  
        public int Views { get;  set; }

        #endregion

        #region Constructor

        public MovieDetails()
        {
 
            CreatedDate = DateTime.Now;
            Views = 0;
           
        }
        #endregion

        #region Methods

        public void AddMovieDetails(string name,TypeOfLanguages language, double rating,int releasedYear, string availability, double buyamount,double rentamount)
        {
            MovieName = name;
            Language = language;
            Rating = rating;
            ReleasedYear = releasedYear;
            Availability = availability;
            BuyAmount = buyamount;
            RentAmount = rentamount;
            
        }

      
        public void ChangeViewsNumbers(int views)
        {
           
            Views = views;
        }

     


        #endregion
    }
}
