using CinemaApp.Admin.Model;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Admin.Function
{
    public class PrintDataFunction
    {
        private CreateDB db = new CreateDB();

        //using table for print out all user data in database
        public void PrintAllUsers()
        {
            var AllUsers = db.Users.ToList();
            var table = new ConsoleTable("Id", "Username", "Password", "Email");
            foreach (var item in AllUsers)
            {
                table.AddRow(item.UserId, item.Username, item.Password, item.Email);
            }
            table.Write();
        }

        //using table for print out all movie data and status in database
        //using if else to check the movie is showing or coming soon
        public void PrintAllMovie()
        {
            var AllUsers = db.Movies.ToList();
            var table = new ConsoleTable("Id", "Movie Title", "Release Date", "Status");
            foreach (var item in AllUsers)
            {
                string ShowingType;
                if (item.IsShowing == true)
                {
                    ShowingType = "Now Showing";
                }
                else
                {
                    ShowingType = "Coming Soon";
                }
                table.AddRow(item.MovieId, item.MovieName, item.ReleaseDate, ShowingType);
            }
            table.Write();
        }

        //This for show out each hall have how many seat
        public void PrintHallDetail()
        {
            var AllHall = db.MovieHalls.ToList();
            var table = new ConsoleTable("Id", "Hall No", "Total Seats");
            foreach (var item in AllHall)
            {
                table.AddRow(item.HallId, item.HallNo, item.TotalSeat);
            }
            table.Write();
        }

        //This for show out each movie at which movie hall
        public void PrintMovieHall()
        {
            var AllHall = db.MovieDetails.ToList();
            var table = new ConsoleTable("Id", "Movie Title", "Hall No");
            foreach (var item in AllHall)
            {
                table.AddRow(item.MovieDetailId, item.MovieId, item.Hall);
            }
        }
    }
}
