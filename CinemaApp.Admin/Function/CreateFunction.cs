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
            new User(){Username = "Mary",Password="654321",Email="" },
            };
            db.Users.AddRange(users);
        }

        //Create Movie Data And Add To Database To Store
        public void CreateMovie()
        {
            List<Movie> movies = new List<Movie>()
            {
                 new Movie(){MovieName="The Justice League", ReleaseDate="Sunday, 01 March 2020",IsShowing=true},
                 new Movie(){MovieName="The Matrix", ReleaseDate="Monday, 02 March 2020",IsShowing=true},
                 new Movie(){MovieName="The Avengers", ReleaseDate="Friday, 06 March 2020",IsShowing=false},
                 new Movie(){MovieName="Lord Of The Rings", ReleaseDate="Tuesday, 10 March 2020",IsShowing=false}
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
                new MovieDetail(){MovieName="The Justice League" ,ShowTime="27/2/2020 10:00:00 AM", HallNo = 3},
                new MovieDetail(){MovieName="The Justice League" ,ShowTime="27/2/2020 2:30:00 PM",HallNo = 4},
                new MovieDetail(){MovieName="The Justice League" ,ShowTime="27/2/2020 6:10:00 PM",HallNo = 3},
                new MovieDetail(){MovieName="The Matrix" ,ShowTime="27/2/2020 10:00:00 AM",HallNo = 3},
                new MovieDetail(){MovieName="The Matrix" ,ShowTime="27/2/2020 2:30:00 PM",HallNo = 4},
                new MovieDetail(){MovieName="The Matrix" ,ShowTime="27/2/2020 6:10:00 PM",HallNo = 3}
            };
            db.MovieDetails.AddRange(movieDetails);
        }


    }
}
