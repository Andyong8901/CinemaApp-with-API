using CinemaApi.Models;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Admin.Function
{
    public class PrintDataFunction
    {
        //using table for print out all user data in database
        public void PrintAllUsers()
        {
            IEnumerable<User> AllUsers;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cinema").Result;
            AllUsers = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
           
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
            IEnumerable<Movie> AllMovies;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cinema").Result;
            AllMovies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            var table = new ConsoleTable("Id", "Movie Title", "Release Date", "Status");
            foreach (var item in AllMovies)
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
            IEnumerable<Hall> AllHall;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cinema").Result;
            AllHall = response.Content.ReadAsAsync<IEnumerable<Hall>>().Result;

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
            IEnumerable<MovieDetail> AllMovieHall;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cinema").Result;
            AllMovieHall = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;

            var table = new ConsoleTable("Id", "Movie Title", "Hall No");
            foreach (var item in AllMovieHall)
            {
                table.AddRow(item.MovieDetailId, item.MovieId, item.HallNo);
            }
        }
    }
}
