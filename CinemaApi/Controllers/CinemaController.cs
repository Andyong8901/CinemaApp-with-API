using Cinema.DomainModelEntity;
using Cinema.InfrastructurePersistance.Repository;
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
        //CreateDB db = new CreateDB();
        CinemaRepository RepoCinema = new CinemaRepository();

        // User Method
        [Route("api/Cinema/GetUser/")]
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return RepoCinema.GetUsers();
        }

        [Route("api/Cinema/GetUser/{id:int}/")]
        [HttpGet]
        public User GetUser(int id)
        {
            return RepoCinema.GetUser(id);
        }

        [Route("api/Cinema/AddUsers/")]
        [HttpPost]
        public void AddUsers(User user)
        {
            RepoCinema.AddUser(user);
        }

        [Route("api/Cinema/AddUser/")]
        [HttpPost]
        public void AddUser(List<User> user)
        {
            RepoCinema.AddUserList(user);
        }

        [Route("api/Cinema/CheckUser/")]
        [HttpPost]
        public User ChekUser(User user)
        {
            var CheckUser = RepoCinema.CheckUserLogin(user);
            return CheckUser;
        }

        //User Method End




        //Movie Method
        [Route("api/Cinema/GetMovie/")]
        [HttpGet]
        public IEnumerable<Movie> GetMovieList()
        {
            return RepoCinema.GetMovies();
        }

        [Route("api/Cinema/GetMovie/{MovieNo:int}")]
        [HttpGet]
        public Movie GetMovieList(int MovieNo)
        {
            var GetMovie = RepoCinema.GetMovie(MovieNo);
            return GetMovie;
        }
        [Route("api/Cinema/AddMovie/")]
        [HttpPost]
        public void AddMovie(List<Movie> movie)
        {
            RepoCinema.AddMovieList(movie);
        }
        //End Movie Method




        //Hall Method
        [Route("api/Cinema/GetHall/")]
        [HttpGet]
        public IEnumerable<Hall> GetHall()
        {
            return RepoCinema.GetHalls();
        }
        [Route("api/Cinema/GetHall/{HallNo:int}")]
        [HttpGet]
        public Hall GetHall(int HallNo)
        {
            var GetHall = RepoCinema.GetHall(HallNo);
            return GetHall;
        }
        [Route("api/Cinema/AddHall/")]
        [HttpPost]
        public void AddHall(List<Hall> halls)
        {
            RepoCinema.AddHallList(halls);
        }
        //Hall Method End




        //Movie Detail Method
        [Route("api/Cinema/GetMovieDetail/")]
        [HttpGet]
        public IEnumerable<MovieDetail> GetMovieDetail()
        {
            return RepoCinema.GetMovieDetail();
        }
        public MovieDetail GetMovieDetails(int id)
        {
            return RepoCinema.GetMovieDetails(id);
        }
        [Route("api/Cinema/GetMovieDetail/{Id:int}")]
        [HttpGet]
        public IEnumerable<MovieDetail> GetMovieDetailById(int Id)
        {
            return RepoCinema.GetMovieDetailByMovie(Id);
        }

        [HttpPost]
        [Route("api/Cinema/AddMovieDetail/")]
        public void AddHallMovieDetail(List<MovieDetail> movieDetails)
        {
            RepoCinema.AddMovieDetailList(movieDetails);
        }
        //Movie Detail Method End




        //Hall Seat Method
        [Route("api/Cinema/GetHallSeat/")]
        [HttpGet]
        public IEnumerable<HallSeat> GetHallSeat()
        {
            return RepoCinema.GetHallSeat();
        }

        [Route("api/Cinema/GetHallSeatByTime/{id:int}/{HallId:int}")]
        [HttpGet]
        public IEnumerable<HallSeat> GetHallSeatByTime(int Id, int HallId)
        {
            return RepoCinema.GetHallSeatByTime(Id, HallId);
        }

        [Route("api/Cinema/GetSeatById/{id:int}")]
        [HttpGet]
        public HallSeat GetSeatById(int? Id)
        {
            return RepoCinema.GetSeatById(Id);
        }

        [Route("api/Cinema/AddMovieSeat/")]
        [HttpPost]
        public void AddMovieSeat(List<HallSeat> Seat)
        {
            RepoCinema.AddMovieSeat(Seat);
        }

        [Route("api/Cinema/DeleteSeat/")]
        [HttpDelete]
        public void DeleteSeat()
        {
            RepoCinema.DeleteSeat();
        }
        //Hall Seat Method End


        //Delete Method
        [Route("api/Cinema/DeleteAll/")]
        [HttpDelete]
        public void DeleteAll()
        {
            RepoCinema.DeleteAll();
        }
        //End Delete Method





        //Movie Cart
        [Route("api/Cinema/GetCartById/{id:int}")]
        [HttpGet]
        public IEnumerable<MovieCart> GetCartById(int? Id)
        {
            return RepoCinema.GetCartById(Id);
        }

        //AddCart
        [Route("api/Cinema/AddCart/")]
        [HttpPost]
        public void AddSeatToCart(MovieCart Cart)
        {
            RepoCinema.AddSeatToCart(Cart);
        }

        [Route("api/Cinema/RemoveCart/{id:int}")]
        [HttpDelete]
        public void RemoveSeat(int id)
        {
            RepoCinema.RemoveSeat(id);
        }

        [Route("api/Cinema/RemoveAllCart/{id:int}")]
        [HttpDelete]
        public void RemoveAllSeat(int id)
        {
            RepoCinema.RemoveAllSeat(id);
        }



        [Route("api/Cinema/ConfirmOrder/{id:int}")]
        [HttpGet]
        public void ConfirmOrder(int id)
        {
            RepoCinema.ConfirmOrder(id);
        }
        //End Movie Cart
    }
}
