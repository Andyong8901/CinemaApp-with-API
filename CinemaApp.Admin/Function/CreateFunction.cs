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
            List<User> users = new List<User>()
            {
            new User(){Username = "John",Password="123456",Email="" },
            new User(){Username = "Mary",Password="654321",Email="" }
            };
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddUser", users).Result;
        }

        //Create Movie Data And Add To Database To Store
        public void CreateMovie()
        {
            List<Movie> movies = new List<Movie>()
            {
                 new Movie(){MovieId=1, MovieName="The Justice League", ReleaseDate=new DateTime(2020,3,10),IsShowing=true},
                 new Movie(){MovieId=2, MovieName="The Matrix", ReleaseDate=new DateTime(2020,3,12),IsShowing=true},
                 new Movie(){MovieId=3, MovieName="The Avengers", ReleaseDate=new DateTime(2020,3,16),IsShowing=false},
                 new Movie(){MovieId=4, MovieName="Lord Of The Rings", ReleaseDate=new DateTime(2020,3,18),IsShowing=false}
            };
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddMovie", movies).Result;
        }

        //Create Hall And Seat Data And Add To Database To Store
        public void CreateHall()
        {
            List<Hall> halls = new List<Hall>()
            {
                new Hall(){ HallNo = 3,SeatRow = 3, SeatColumn = 10},
                new Hall(){ HallNo = 4,SeatRow = 4, SeatColumn = 10}
            };
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddHall", halls).Result;
        }

        //Create Hall Movie Data And Add To Database To Store
        public void CreateHallMovieDetail()
        {
            List<MovieDetail> movieDetails = new List<MovieDetail>()
            {
                new MovieDetail(){MovieDetailId =101,MovieId =1 ,ShowTime=new DateTime(2020,3,15,10,00,0),HallNo =3},
                new MovieDetail(){MovieDetailId =102,MovieId =1 ,ShowTime=new DateTime(2020,3,15,14,30,0),HallNo =4},
                new MovieDetail(){MovieDetailId =103,MovieId =1 ,ShowTime=new DateTime(2020,3,15,18,10,0),HallNo =3},
                new MovieDetail(){MovieDetailId =104,MovieId =2 ,ShowTime=new DateTime(2020,3,16,10,00,0),HallNo =3},
                new MovieDetail(){MovieDetailId =105,MovieId =2 ,ShowTime=new DateTime(2020,3,16,14,30,0),HallNo =4},
                new MovieDetail(){MovieDetailId =106,MovieId =2 ,ShowTime=new DateTime(2020,3,16,18,10,0),HallNo =3}
            };
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/AddHallMovieDetail", movieDetails).Result;
        }
        public void CreateMovieSeat()
        {
            IEnumerable<MovieDetail> MovieShowList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cinema").Result;
            MovieShowList = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;
            foreach (var item in MovieShowList)
            {
                Hall hall;
                HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Cinema").Result;
                hall = responses.Content.ReadAsAsync<Hall>().Result;

                SeatNum(hall.SeatRow, hall.SeatColumn, item.ShowTime, item.MovieId);
            };
        }

        public void SeatNum(int SeatRow, int SeatColumn, DateTime ShowTime, int MovieId)
        {
            Random rnd1 = new Random();
            List<MovieHallSeat> Seat = new List<MovieHallSeat>();
            Thread.Sleep(1);
            for (var x = 1; x <= SeatRow; x++)
            {
                for (var i = 1; i <= SeatColumn; i++)
                {
                    SeatStatus g = (SeatStatus)rnd1.Next(2);

                    MovieHallSeat class1 = new MovieHallSeat
                    {
                        SeatNumber = x + "," + i,
                        Seatstatus = g,
                        ShowTime = ShowTime,
                        MovieId = MovieId
                    };
                    Seat.Add(class1);
                }
            }
            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinema/Addmovie", Seat).Result;
        }
    }
}
