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
        private HttpResponseMessage response;
        //User Start
        //using table for print out all user data in database
        public void PrintAllUsers()
        {
            //Get All User Detail
            IEnumerable<User> AllUsers;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetUser").Result;
            AllUsers = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            //End Get All User Detail

            var table = new ConsoleTable("Id", "Username", "Password", "Email");
            foreach (var item in AllUsers)
            {
                table.AddRow(item.UserId, item.Username, item.Password, item.Email);
            }
            table.Write();
        }
        //User End




        //Movie Start

        //using table for print out all movie data and status in database
        //using if else to check the movie is showing or coming soon
        public void PrintAllMovie()
        {
            //Get All Movie Detail
            IEnumerable<Movie> AllMovies;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetMovie/").Result;
            AllMovies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            //End Get All Movie Detail

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

        public void PrintMovieSeat()
        {
            //Get Movie Detail
            IEnumerable<MovieDetail> AllMovieHall;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetMovieDetail").Result;
            AllMovieHall = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;
            //End Get Movie Detail

            //Get Hall Seat
            IEnumerable<HallSeat> AllHallSeat;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetHallSeat").Result;
            AllHallSeat = response.Content.ReadAsAsync<IEnumerable<HallSeat>>().Result;
            //End Get Hall Seat

            foreach (var itemMovie in AllMovieHall)
            {
                var FilterMovie = AllHallSeat.ToList().Where(m => m.HallId == itemMovie.HallId && m.ShowTime == itemMovie.ShowTime);
                Console.WriteLine($"Movie Name : {itemMovie.Movie.MovieName} | Show Time : {itemMovie.ShowTime} | Hall No : {itemMovie.Hall.HallNo}");
                foreach (var item in FilterMovie)
                {
                    if (item.Seatstatus == SeatStatus.Empty)
                    {
                        Console.Write(item.SeatNumber + "E" + "\t");
                    }
                    else
                    {
                        Console.Write(item.SeatNumber + "T" + "\t");
                    }

                    if (item.SeatNumber == "1,10" || item.SeatNumber == "2,10" || item.SeatNumber == "3,10" || item.SeatNumber == "4,10")
                    {
                        Console.WriteLine("\n");
                    }
                }
                Console.WriteLine("\n\n");
            }
        }
        //Movie End




        //Hall Start
        //This for show out each hall have how many seat
        public void PrintHallDetail()
        {
            //Get Hall Detail
            IEnumerable<Hall> AllHall;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetHall").Result;
            AllHall = response.Content.ReadAsAsync<IEnumerable<Hall>>().Result;
            //End Get Hall Detail

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
            //Get Movie Detail
            IEnumerable<MovieDetail> AllMovieHall;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetMovieDetail").Result;
            AllMovieHall = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;
            //End Get Movie Detail

            var table = new ConsoleTable("Id", "Movie Title", "Hall No");
            foreach (var item in AllMovieHall)
            {
                table.AddRow(item.MovieDetailId, item.Movie.MovieName, item.Hall.HallNo);
            }
            table.Write();
            Console.WriteLine("\n\n");
        }
        //Hall End
    }
}
