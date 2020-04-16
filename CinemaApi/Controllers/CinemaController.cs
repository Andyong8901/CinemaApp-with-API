using CinemaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaApi.Controllers
{
    public class CinemaController : ApiController
    {
        CreateDB db = new CreateDB();


        // User Method
        [Route("api/Cinema/GetUser/")]
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return db.Users.ToList();
        }

        [Route("api/Cinema/AddUser/{id:int}/")]
        [HttpGet]
        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }

        [Route("api/Cinema/AddUser/")]
        [HttpPost]
        public void AddUser(List<User> user)
        {
            var check = db.Users.ToList();
            if (check.Count==0)
            {
                db.Users.AddRange(user);
                Save();
            }
        }
        //User Method End




        //Movie Method
        [Route("api/Cinema/GetMovie/")]
        [HttpGet]
        public IEnumerable<Movie> GetMovieList()
        {
            return db.Movies.ToList();
        }
        [Route("api/Cinema/GetMovie/{MovieNo:int}")]
        [HttpGet]
        public Movie GetMovieList(int MovieNo)
        {
            var GetMovie = db.Movies.SingleOrDefault(m => m.MovieNo == MovieNo);
            return GetMovie;
        }
        [Route("api/Cinema/AddMovie/")]
        [HttpPost]
        public void AddMovie(List<Movie> movie)
        {
            var CheckMovie = db.Movies.ToList();
            if (CheckMovie.Count() == 0)
            {
                db.Movies.AddRange(movie);
            }
            Save();
        }
        //End Movie Method




        //Hall Method
        [Route("api/Cinema/GetHall/")]
        [HttpGet]
        public IEnumerable<Hall> GetHall()
        {
            return db.Halls.ToList();
        }
        [Route("api/Cinema/GetHall/{HallNo:int}")]
        [HttpGet]
        public Hall GetHall(int HallNo)
        {
            var GetHall = db.Halls.SingleOrDefault(m => m.HallNo == HallNo);
            return GetHall;
        }
        [Route("api/Cinema/AddHall/")]
        [HttpPost]
        public void AddHall(List<Hall> halls)
        {
            var CheckHall = db.Halls.ToList();
            if (CheckHall.Count() == 0)
            {
                db.Halls.AddRange(halls);
            }
            Save();
        }
        //Hall Method End




        //Movie Detail Method
        [Route("api/Cinema/GetMovieDetail/")]
        [HttpGet]
        public IEnumerable<MovieDetail> GetMovieDetail()
        {
            return db.MovieDetails.ToList();
        }

        [HttpPost]
        [Route("api/Cinema/AddMovieDetail/")]
        public void AddHallMovieDetail(List<MovieDetail> movieDetails)
        {
            var CheckMovieDetail = db.MovieDetails.ToList();
            if (CheckMovieDetail.Count() ==0)
            {
                db.MovieDetails.AddRange(movieDetails);
            }
            Save();
        }
        //Movie Detail Method End




        //Hall Seat Method
        [Route("api/Cinema/GetHallSeat/")]
        [HttpGet]
        public IEnumerable<HallSeat> GetHallSeat()
        {
            return db.HallSeats.ToList();
        }
        [Route("api/Cinema/AddMovieSeat/")]
        [HttpPost]
        public void AddMovieSeat(List<HallSeat> Seat)
        {
            var CheckSeat = db.HallSeats.ToList();
            if (CheckSeat.Count() == 0)
            {
                db.HallSeats.AddRange(Seat);
            }
            Save();
        }
        [Route("api/Cinema/DeleteSeat/")]
        [HttpDelete]
        public void DeleteSeat()
        {
            var Seat = db.HallSeats.ToList();
            if (Seat.Count() != 0)
            {
                db.HallSeats.RemoveRange(Seat);
                Save();
            }
        }
        //Hall Seat Method End


        public void Save()
        {
            db.SaveChanges();
        }


        [Route("api/Cinema/DeleteAll/")]
        [HttpDelete]
        public void DeleteAll()
        {
            var Seat = db.HallSeats.ToList();
            if (Seat.Count() != 0)
            {
                db.HallSeats.RemoveRange(Seat);
            }

            var MovieDetail = db.MovieDetails.ToList();
            if (MovieDetail.Count() != 0)
            {
                db.MovieDetails.RemoveRange(MovieDetail);
            }

            var Hall = db.Halls.ToList();
            if (Hall.Count() != 0)
            {
                db.Halls.RemoveRange(Hall);
            }

            var Movie = db.Movies.ToList();
            if (Movie.Count() != 0)
            {
                db.Movies.RemoveRange(Movie);
            }

            var User = db.Users.ToList();
            if (User.Count() != 0)
            {
                db.Users.RemoveRange(User);
            }
            Save();
        }





        // PUT: api/Cinema/5
        //public void Put(int id, [FromBody]string value)
        //{

        //}




    }
}
