using CinemaApp.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Admin.Function
{
    public class CreateFunction
    {
        private CreateDB db = new CreateDB();
        //Create User Data And Add To Database To Store
        public void CreateUser()
        {
            List<User> users = new List<User>()
            {
            new User(){Username = "John",Password="123456",Email="" },
            new User(){Username = "Mary",Password="654321",Email="" }
            };
            db.Users.AddRange(users);
        }

        //Create Movie Data And Add To Database To Store
        public void CreateMovie()
        {
            List<Movie> movies = new List<Movie>()
            {
                 new Movie(){MovieId=1,MovieName="The Justice League", ReleaseDate=new DateTime(2020,3,10),IsShowing=true},
                 new Movie(){MovieId=2,MovieName="The Matrix", ReleaseDate=new DateTime(2020,3,12),IsShowing=true},
                 new Movie(){MovieId=3,MovieName="The Avengers", ReleaseDate=new DateTime(2020,3,16),IsShowing=false},
                 new Movie(){MovieId=4,MovieName="Lord Of The Rings", ReleaseDate=new DateTime(2020,3,18),IsShowing=false}
            };
            db.Movies.AddRange(movies);
        }

        //Create Hall And Seat Data And Add To Database To Store
        public void CreateHall()
        {
            List<MovieHall> halls = new List<MovieHall>()
            {
                new MovieHall(){ HallNo = 3,SeatRow = 3, SeatColumn = 10},
                new MovieHall(){ HallNo = 4,SeatRow = 4, SeatColumn = 10}
            };
            db.MovieHalls.AddRange(halls);
        }

        //Create Hall Movie Data And Add To Database To Store
        public void CreateHallMovieDetail()
        {
            List<MovieDetail> movieDetails = new List<MovieDetail>()
            {
                new MovieDetail(){MovieDetailId =101,MovieId =1 ,ShowTime=new DateTime(2020,3,15,10,00,0),Hall =3},
                new MovieDetail(){MovieDetailId =102,MovieId =1 ,ShowTime=new DateTime(2020,3,15,14,30,0),Hall =4},
                new MovieDetail(){MovieDetailId =103,MovieId =1 ,ShowTime=new DateTime(2020,3,15,18,10,0),Hall =3},
                new MovieDetail(){MovieDetailId =104,MovieId =2 ,ShowTime=new DateTime(2020,3,16,10,00,0),Hall =3},
                new MovieDetail(){MovieDetailId =105,MovieId =2 ,ShowTime=new DateTime(2020,3,16,14,30,0),Hall =4},
                new MovieDetail(){MovieDetailId =106,MovieId =2 ,ShowTime=new DateTime(2020,3,16,18,10,0),Hall =3}
            };
            db.MovieDetails.AddRange(movieDetails);
        }


    }
}
