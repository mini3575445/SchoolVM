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

        public IEnumerable<Customers> Get()
        {

            var customers=db.Customers;

            return customers;
        }

        // GET api/values/5
        public Customers Get(string id)
        {
            var customers = db.Customers.Find(id);

            //var customers = db.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
            //select * from Customers where CustomerID=@id

            return customers;
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
