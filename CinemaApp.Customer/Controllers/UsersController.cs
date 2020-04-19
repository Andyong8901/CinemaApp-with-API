using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CinemaApi.Models;

namespace CinemaApp.Customer.Controllers
{
    public class UsersController : Controller
    {
        private HttpResponseMessage response;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            response = GlobalVariables.WebApiClient.PostAsJsonAsync($"Cinema/CheckUser/", user).Result;
            var CheckUser = response.Content.ReadAsAsync<User>().Result;

            if (CheckUser != null)
            {
                Session["UserId"] = CheckUser.UserId;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        { 
            response = GlobalVariables.WebApiClient.PostAsJsonAsync($"Cinema/AddUsers/",user).Result;
            return RedirectToAction("Login");
        }

        // GET: Movies
        public ActionResult Index()
        {
            IEnumerable<Movie> AllMovie;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetMovie").Result;
            AllMovie = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            return View(AllMovie);
        }

        // GET: Movie Detail
        public ActionResult SelectedMovie(int? id)
        {
            IEnumerable<MovieDetail> AllMovieDetail;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetMovieDetail/{id}").Result;
            AllMovieDetail = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;

            return View(AllMovieDetail);
        }

        public ActionResult SelectedMovieTime(int? id, int HallId)
        {
            IEnumerable<HallSeat> hallSeat;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetHallSeatByTime/{id}/{HallId}").Result;
            hallSeat = response.Content.ReadAsAsync<IEnumerable<HallSeat>>().Result;

            return View(hallSeat);
        }

        public ActionResult ViewCart()
        {
            var UserId = Convert.ToInt32(Session["UserId"]);

            IEnumerable<MovieCart> MovieCarts;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetCartById/{UserId}/").Result;
            MovieCarts = response.Content.ReadAsAsync<IEnumerable<MovieCart>>().Result;

            ViewBag.Total = TotalAll(UserId);

            return View(MovieCarts);
        }


        //SelectSeat
        public ActionResult SelectSeat(int? SeatId)
        {
            var UserId = Convert.ToInt32(Session["UserId"]);

            IEnumerable<MovieCart> MovieCarts;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetCartById/{UserId}/").Result;
            MovieCarts = response.Content.ReadAsAsync<IEnumerable<MovieCart>>().Result;
            var checkOrderCart = MovieCarts.SingleOrDefault(mc=>mc.SeatId == SeatId);
            
            
            if (checkOrderCart == null)
            {
                HallSeat hallSeat;
                response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetSeatById/{SeatId}/").Result;
                hallSeat = response.Content.ReadAsAsync<HallSeat>().Result;

                response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetUser/{UserId}").Result;
                var CheckUser = response.Content.ReadAsAsync<User>().Result;


                IEnumerable<MovieDetail> AllMovieDetail;
                response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetMovieDetail/").Result;
                AllMovieDetail = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;

                var GetMovieName = AllMovieDetail.SingleOrDefault(md => md.ShowTime == hallSeat.ShowTime && md.HallId == hallSeat.HallId);

                MovieCart cart = new MovieCart()
                {
                    SeatNo = hallSeat.SeatNumber,
                    SeatId = hallSeat.SeatId,
                    UserId = CheckUser.UserId,
                    Amount = hallSeat.SeatPrice,
                    MovieName = GetMovieName.Movie.MovieName
                };

                response = GlobalVariables.WebApiClient.PostAsJsonAsync($"Cinema/AddCart/", cart).Result;

                return Json(new { CheckSeat = true }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new { CheckSeat = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveCart(int? id)
        {
            response = GlobalVariables.WebApiClient.DeleteAsync($"Cinema/RemoveCart/{id}").Result;
            return RedirectToAction("ViewCart");
        }

        public ActionResult RemoveAllCart()
        {
            var UserId = Convert.ToInt32(Session["UserId"]);
            response = GlobalVariables.WebApiClient.DeleteAsync($"Cinema/RemoveAllCart/{UserId}").Result;
            return RedirectToAction("Index");
        }


        public ActionResult ConfirmOrder()
        {
            var UserId = Convert.ToInt32(Session["UserId"]);
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/ConfirmOrder/{UserId}").Result;
            RemoveAllCart();
            return RedirectToAction("Index");
        }


        public double TotalAll(int UserId)
        {
            double Total = 0;

            IEnumerable<MovieCart> AllCart;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetCartById/{UserId}").Result;
            AllCart = response.Content.ReadAsAsync<IEnumerable<MovieCart>>().Result;
            foreach (var item in AllCart)
            {
                Total += item.Amount;
            }
            return Total;
        }

        public ActionResult UserCheckName(string Username)
        {
            var UserId = Convert.ToInt32(Session["UserId"]);

            IEnumerable<User> CUsername;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetUser/").Result;
            CUsername = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            var GetResult = CUsername.SingleOrDefault(cn => cn.Username == Username);
            if (GetResult !=null)
            {
                var text = "This Username Is Exist , Please Try Another Username";
                return Json(new { text, Checkname = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { CheckSeat = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserCheckEmail(string Email)
        {
            var UserId = Convert.ToInt32(Session["UserId"]);

            IEnumerable<User> CUsername;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetUser/").Result;
            CUsername = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

            var GetResult = CUsername.SingleOrDefault(cn => cn.Email == Email);
            if (GetResult != null)
            {
                var text = "This Email Is Exist , Please Try Another Email";
                return Json(new {text, Checkemail = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { CheckSeat = true }, JsonRequestBehavior.AllowGet);
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
