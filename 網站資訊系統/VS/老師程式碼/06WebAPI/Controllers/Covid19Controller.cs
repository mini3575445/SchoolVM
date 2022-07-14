using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _06WebAPI.Models;
using Newtonsoft.Json;

namespace _06WebAPI.Controllers
{
    public class Covid19Controller : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            string url = "https://covid-19.nchc.org.tw/api/covid19?CK=covid-19@nchc.org.tw&querydata=5002";
            HttpClient client =new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var resp = await client.GetStringAsync(url);

            var collection=JsonConvert.DeserializeObject<IEnumerable<Covid19>>(resp);

            return View(collection);
        }
    }
}