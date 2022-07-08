using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _06WebAPI.Models;
namespace _06WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET api/values
        public IEnumerable<Customers> Get()
        {
            var customers = db.Customers;
            return customers;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
