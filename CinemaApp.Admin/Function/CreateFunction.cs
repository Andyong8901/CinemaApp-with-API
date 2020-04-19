using CinemaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CinemaApp.Admin.Function
{
    public class CreateFunction
    {
        private HttpResponseMessage response;

        //Create User Data And Add To Database To Store
        public void CreateUser()
        {
            //Create A List To Store All User Detail
            List<User> users = new List<User>()
            {
            new User(){Username = "John",Password="123456",Email="" },
            new User(){Username = "Mary",Password="654321",Email="" }
            };
            //End Create
            //Pass In To Database To Store All User Detail
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddUser", users).Result;
            //End Pass
        }

        //Create Movie Data And Add To Database To Store
        public void CreateMovie()
        {
            //Create A List To Store All Movie Detail
            List<Movie> movies = new List<Movie>()
            {
                 new Movie(){MovieNo=1, MovieName="The Justice League", ReleaseDate=new DateTime(2020,3,10),IsShowing=true},
                 new Movie(){MovieNo=2, MovieName="The Matrix", ReleaseDate=new DateTime(2020,3,12),IsShowing=true},
                 new Movie(){MovieNo=3, MovieName="The Avengers", ReleaseDate=new DateTime(2020,3,16),IsShowing=false},
                 new Movie(){MovieNo=4, MovieName="Lord Of The Rings", ReleaseDate=new DateTime(2020,3,18),IsShowing=false}
            };
            //End Create
            //Pass In To Database To Store All Movie Detail
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddMovie", movies).Result;
            //End Pass
        }

        //Create Hall And Seat Data And Add To Database To Store
        public void CreateHall()
        {
            //Create A List To Store All Hall Detail
            List<Hall> halls = new List<Hall>()
            {
                new Hall(){ HallNo = 3,SeatRow = 3, SeatColumn = 10},
                new Hall(){ HallNo = 4,SeatRow = 4, SeatColumn = 10}
            };
            //End Create
            //Pass In To Database To Store All Hall Detail
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddHall", halls).Result;
            //End Pass
        }

        //Create Hall Movie Data And Add To Database To Store
        public void CreateShowingMovie()
        {           
            //Create A List To Store All Showing Movie Detail
            List<MovieDetail> movieDetails = new List<MovieDetail>()
            {
                new MovieDetail(){MovieDetailId =101,MovieId =FindMovie(1) ,ShowTime=new DateTime(2020,3,15,10,00,0),HallId =FindHall(3)},
                new MovieDetail(){MovieDetailId =102,MovieId =FindMovie(1) ,ShowTime=new DateTime(2020,3,15,14,30,0),HallId =FindHall(4)},
                new MovieDetail(){MovieDetailId =103,MovieId =FindMovie(1) ,ShowTime=new DateTime(2020,3,15,18,10,0),HallId =FindHall(4)},
                new MovieDetail(){MovieDetailId =104,MovieId =FindMovie(2) ,ShowTime=new DateTime(2020,3,16,10,00,0),HallId =FindHall(3)},
                new MovieDetail(){MovieDetailId =105,MovieId =FindMovie(2) ,ShowTime=new DateTime(2020,3,16,14,30,0),HallId =FindHall(4)},
                new MovieDetail(){MovieDetailId =106,MovieId =FindMovie(2) ,ShowTime=new DateTime(2020,3,16,18,10,0),HallId =FindHall(3)}
            };
            //End Create
            
            //Pass In To Database To Store All Showing Movie Detail
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddMovieDetail", movieDetails).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Add Movie Hall Data Failed");
            }
            Console.WriteLine("    Add Showing Movie Done");
            //End Pass
        }

        public int FindMovie(int? MovieNo)
        {
            //Get Movie Detail
            Movie GetMovies;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetMovie/{MovieNo}").Result;
            GetMovies = response.Content.ReadAsAsync<Movie>().Result;
            //End Get Movie Detail
            if (GetMovies == null)
            {
                return 0;
            }
            return GetMovies.MovieId;
        }

        public int FindHall(int? HallNo)
        {
            //Get Hall Detail
            Hall GetHall;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetHall/{HallNo}").Result;
            GetHall = response.Content.ReadAsAsync<Hall>().Result;
            //End Get Hall Detail
            if (GetHall == null)
            {
                return 0;
            }
            return GetHall.HallId;
        }

        public void CreateMovieSeat(string Option)
        {
            //Get Movie Detail
            IEnumerable<MovieDetail> MovieShowList;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetMovieDetail").Result;
            MovieShowList = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;
            //End Get Movie Detail

            //if (MovieShowList.Count() == 0)
            //{
            //    Console.WriteLine("No Movie Detail Data Can't Not Create Hall Seat");
            //}

            if (Option != "NoStatus")
            {
                response = GlobalVariables.WebApiClient.DeleteAsync("Cinema/DeleteSeat/").Result;
            }
            List<HallSeat> Seat = new List<HallSeat>();
            foreach (var item in MovieShowList)
            {
                double SeatPrice = 15;
                Random rnd1 = new Random();
                for (var x = 1; x <= item.Hall.SeatRow; x++)
                {
                    if (item.Hall.SeatRow >=1)
                    {
                        SeatPrice += 5;
                    }
                    for (var i = 1; i <= item.Hall.SeatColumn; i++)
                    {
                        SeatStatus Status;
                        if (Option != "NoStatus")
                        {
                            Thread.Sleep(1);
                            Status = (SeatStatus)rnd1.Next(2);
                        }
                        else
                        {
                            Status = SeatStatus.Empty;
                        }
                        HallSeat class1 = new HallSeat
                        {
                            SeatNumber = x + "," + i,
                            Seatstatus = Status,
                            ShowTime = item.ShowTime,
                            SeatPrice = SeatPrice,
                            HallId = item.HallId,
                        };
                        Seat.Add(class1);
                    }
                }
            };
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddMovieSeat", Seat).Result;
        }
    }
}
