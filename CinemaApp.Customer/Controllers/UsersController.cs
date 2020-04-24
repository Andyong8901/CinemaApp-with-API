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
        public User CheckUser()
        {
            var CustomerId = Convert.ToInt32(Session["UserId"]);

            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetUser/{CustomerId}/").Result;
            var CheckLogin = response.Content.ReadAsAsync<User>().Result;

            if (CheckLogin == null)
            {
                RedirectToAction("Login");
            }
            return CheckLogin;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            response = GlobalVariables.WebApiClient.PostAsJsonAsync($"Cinema/AddUsers/", user).Result;
            return RedirectToAction("Login");
        }

        // GET: Movies
        public ActionResult Index()
        {
            CheckUser();
            IEnumerable<Movie> AllMovie;
            response = GlobalVariables.WebApiClient.GetAsync("Cinema/GetMovie").Result;
            AllMovie = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            return View(AllMovie);
        }

        // GET: Movie Detail
        public ActionResult SelectedMovie(int? id)
        {
            CheckUser();
            IEnumerable<MovieDetail> AllMovieDetail;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetMovieDetail/{id}").Result;
            AllMovieDetail = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;

            return View(AllMovieDetail);
        }

        public ActionResult SelectedMovieTime(int? id, int HallId)
        {
            CheckUser();
            Session["MovieDetail"] = id;
            Session["HallId"] = HallId;
            IEnumerable<HallSeat> hallSeat;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetHallSeatByTime/{id}/{HallId}").Result;
            hallSeat = response.Content.ReadAsAsync<IEnumerable<HallSeat>>().Result;

            return View(hallSeat);
        }

        public ActionResult ViewCart()
        {
            var user = CheckUser();
            ViewBag.DetailId =Convert.ToInt32(Session["MovieDetail"]);
            ViewBag.HallId = Convert.ToInt32(Session["HallId"]);
            IEnumerable<MovieCart> MovieCarts;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetCartById/{user.UserId}/").Result;
            MovieCarts = response.Content.ReadAsAsync<IEnumerable<MovieCart>>().Result;

            ViewBag.Total = TotalAll(user.UserId);

            return View(MovieCarts);
        }


        //SelectSeat
        public ActionResult SelectSeat(int? SeatId)
        {
            var user = CheckUser();

            IEnumerable<MovieCart> MovieCarts;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetCartById/{user.UserId}/").Result;
            MovieCarts = response.Content.ReadAsAsync<IEnumerable<MovieCart>>().Result;
            var checkOrderCart = MovieCarts.SingleOrDefault(mc => mc.SeatId == SeatId);

            if (checkOrderCart == null)
            {
                HallSeat hallSeat;
                response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetSeatById/{SeatId}/").Result;
                hallSeat = response.Content.ReadAsAsync<HallSeat>().Result;

                IEnumerable<MovieDetail> AllMovieDetail;
                response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetMovieDetail/").Result;
                AllMovieDetail = response.Content.ReadAsAsync<IEnumerable<MovieDetail>>().Result;

                var GetMovieName = AllMovieDetail.SingleOrDefault(md => md.ShowTime == hallSeat.ShowTime && md.HallId == hallSeat.HallId);

                MovieCart cart = new MovieCart()
                {
                    SeatNo = hallSeat.SeatNumber,
                    SeatId = hallSeat.SeatId,
                    UserId = user.UserId,
                    Amount = hallSeat.SeatPrice,
                    MovieName = GetMovieName.Movie.MovieName
                };

                response = GlobalVariables.WebApiClient.PostAsJsonAsync($"Cinema/AddCart/", cart).Result;
                var text = "Successful Add Cart";
                return Json(new { text, CheckSeat = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var text = "This Seat Already Have Inside Cart";
                return Json(new { text, CheckSeat = false }, JsonRequestBehavior.AllowGet);
            }
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
            IEnumerable<User> CUsername;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetUser/").Result;
            CUsername = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            var GetResult = CUsername.SingleOrDefault(cn => cn.Username == Username);
            if (GetResult != null)
            {
                var text = "This Username Is Exist , Please Try Another Username";
                return Json(new { text, Checkname = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { CheckSeat = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserCheckEmail(string Email)
        {
            IEnumerable<User> CUsername;
            response = GlobalVariables.WebApiClient.GetAsync($"Cinema/GetUser/").Result;
            CUsername = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

            var GetResult = CUsername.SingleOrDefault(cn => cn.Email == Email);
            if (GetResult != null)
            {
                var text = "This Email Is Exist , Please Try Another Email";
                return Json(new { text, Checkemail = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { CheckSeat = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View();
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
