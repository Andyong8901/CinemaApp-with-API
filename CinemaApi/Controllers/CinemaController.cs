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
        // GET: api/Cinema
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cinema/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cinema
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cinema/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cinema/5
        public void Delete(int id)
        {
        }
    }
}
