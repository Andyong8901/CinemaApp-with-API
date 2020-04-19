using Cinema.DomainModelEntity;
using Cinema.DomainModelEntity.Interface;
using CinemaApi.InfrastructurePersistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.InfrastructurePersistance.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private CreateDB db = new CreateDB();
        //User Start
        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        }
        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
        }
        public void AddUserList(List<User> user)
        {
            var check = db.Users.ToList();
            if (check.Count == 0)
            {
                db.Users.AddRange(user);
            }
        }
        public User CheckUserLogin(User user)
        {
            var CheckUser = db.Users.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            return CheckUser;
        }
        //User End

        //Movie Start
        public IEnumerable<Movie> GetMovies()
        {
            return db.Movies;
        }
        public Movie GetMovie(int id)
        {
            return db.Movies.Find(id);
        }
        public void AddMovieList(List<Movie> movies)
        {
            var check = db.Movies.ToList();
            if (check.Count == 0)
            {
                db.Movies.AddRange(movies);
            }
        }
        //Movie End

        //Hall Start
        public IEnumerable<Hall> GetHalls()
        {
            return db.Halls;
        }
        public Hall GetHall(int id)
        {
            return db.Halls.Find(id);
        }
        public void AddHallList(List<Hall> halls)
        {
            var check = db.Halls.ToList();
            if (check.Count == 0)
            {
                db.Halls.AddRange(halls);
            }
        }
        //Hall End

        //Movie Detail Start
        public IEnumerable<MovieDetail> GetMovieDetail()
        {
            return db.MovieDetails;
        }
        public MovieDetail GetMovieDetails(int id)
        {
            return db.MovieDetails.Find(id);
        }
        public void AddMovieDetailList(List<MovieDetail> halls)
        {
            var check = db.MovieDetails.ToList();
            if (check.Count == 0)
            {
                db.MovieDetails.AddRange(halls);
            }
        }
        public IEnumerable<MovieDetail> GetMovieDetailByMovie(int Id)
        {
            return db.MovieDetails.ToList().Where(md => md.MovieId == Id);
        }
        //Movie Detail End

        //Hall Seat Start

        public IEnumerable<HallSeat> GetHallSeat()
        {
            return db.HallSeats.ToList();
        }
        public IEnumerable<HallSeat> GetHallSeatByTime(int Id, int HallId)
        {
            var GetMovieDetail = GetMovieDetails(Id);
            return db.HallSeats.ToList().Where(hs => hs.ShowTime == GetMovieDetail.ShowTime && hs.HallId == HallId);
        }
        public HallSeat GetSeatById(int? Id)
        {
            return db.HallSeats.SingleOrDefault(hs => hs.SeatId == Id);
        }
        public void AddMovieSeat(List<HallSeat> Seat)
        {
            var CheckSeat = db.HallSeats.ToList();
            if (CheckSeat.Count() == 0)
            {
                db.HallSeats.AddRange(Seat);
            }
            Save();
        }
        public void DeleteSeat()
        {
            var Seat = db.HallSeats.ToList();
            if (Seat.Count() != 0)
            {
                db.HallSeats.RemoveRange(Seat);
                Save();
            }
        }
        //Hall Seat End

        public void Save()
        {
            db.SaveChanges();
        }


        //Delete Method
        public void DeleteAll()
        {
            var Cart = db.MovieCarts.ToList();
            if (Cart.Count() != 0)
            {
                db.MovieCarts.RemoveRange(Cart);
            }
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
        //End Delete Method





        //Movie Cart
        public IEnumerable<MovieCart> GetCartById(int? Id)
        {
            return db.MovieCarts.ToList().Where(hs => hs.UserId == Id);
        }

        public void AddSeatToCart(MovieCart Cart)
        {
            db.MovieCarts.Add(Cart);
            Save();
        }

        public void RemoveSeat(int id)
        {
            var Seat = db.MovieCarts.Find(id);
            db.MovieCarts.Remove(Seat);
            Save();
        }

        public void RemoveAllSeat(int id)
        {
            var GetUserCart = db.MovieCarts.ToList().Where(mc => mc.UserId == id);
            db.MovieCarts.RemoveRange(GetUserCart);
            Save();
        }



        public void ConfirmOrder(int id)
        {
            var GetUserCart = db.MovieCarts.ToList().Where(mc => mc.UserId == id);
            foreach (var item in GetUserCart)
            {
                var GetSeatId = db.HallSeats.Find(item.SeatId);
                GetSeatId.Seatstatus = SeatStatus.Taken;
                Save();
            }
        }
        //End Movie Cart
    }
}
