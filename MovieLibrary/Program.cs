using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select the following options");
            Console.WriteLine("1. Librarian");
            Console.WriteLine("2. User");
            var option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
             case 1:
             Console.Write("Enter the user id : ");
            var userid = Console.ReadLine();
            Console.WriteLine("Enter the password : ");
            var password = Console.ReadLine();
            var autentication = new Autentication();
            var result = autentication.Autentications(userid, password);
            if (result == true)
            {
                while (true)
                {
                    Console.WriteLine("Please select from the below options : ");
                    Console.WriteLine("1.Add new movie details");
                    Console.WriteLine("2.Edit an existing movie details");
                    Console.WriteLine("3. Delete a movie details");
                    Console.WriteLine("4. Exit out");
                    var options = Convert.ToInt32(Console.ReadLine());
                    switch (options)
                    {
                                case 1:
                                    Console.Write("Enter the name of the movie : ");
                                    var moviename = Console.ReadLine();
                                    Console.Write("Select the language : ");
                                    //covert enum to an array
                                    var Languages=Enum.GetNames(typeof(TypeOfLanguage));
                                    //Loop through the array
                                    for( var i=0; i<Languages.Length;i++)
                                    {
                                        Console.WriteLine($"{i}.{Languages[i]}");
                                    }
                                   var Language = Enum.Parse<TypeOfLanguage>(Console.ReadLine());
                                    Console.Write("Enter the Rating : ");
                                    var rating = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Enter the year released : ");
                                    var release = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter the site where the movie is available : ");
                                    var availability = Console.ReadLine();
                                    var moviedetails =Movielibrarian.CreateMovieDetails(moviename, Language, rating, release, availability);
                                    Console.WriteLine($"TrackNumber : {moviedetails.TrackNumber}, CreatedDate : {moviedetails.CreatedDate}, MovieName : {moviedetails.MovieName}, language :{moviedetails.Language}," +
                                        $"Rating : {moviedetails.Rating}, YearOfRelease : {moviedetails.ReleasedYear}, Availability : {moviedetails.Availability}");
                                    break;

                                case 2:
                                    Console.Write("Please enter the MovieName to be edited : ");
                                    var movie = Console.ReadLine();

                                    break;
                                case 3:
                                    break;
                                case 4:
                                    Console.WriteLine("Thanks for exiting!");
                                    return;
                    }
                }

            }
            else
            {
                Console.WriteLine("Not a valid user, please select a valid choice");
            }
                    break;
        }
        
            }

        

        }
    }

