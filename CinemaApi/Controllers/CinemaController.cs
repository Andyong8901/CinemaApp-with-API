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
        // GET: api/Cinema
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // GET: api/Cinema/5
        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }
        public Hall GetMovieHall(int HallNo)
        {
            return db.Halls.SingleOrDefault(h=>h.HallNo == HallNo);
        }

        // POST: api/Cinema

        [Route("api/Cinema/AddUser/")]
        [HttpPost]
        public void AddUser(List<User> user)
        {
            db.Users.AddRange(user);
            Save();
        }

        [Route("api/Cinema/AddMovie/")]
        [HttpPost]
        public void AddMovie(List<Movie> movie)
        {
            db.Movies.AddRange(movie);
            Save();
        }
        
        [Route("api/Cinema/AddHall/")]
        [HttpPost]
        public void AddHall(List<Hall> halls)
        {
            db.Halls.AddRange(halls);
            Save();
        }
        // PUT: api/Cinema/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Cinema/5
        public void Delete(int id)
        {
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
