using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;   //Threading執行緒
using System.Net.Http;
using Newtonsoft.Json;

using _06WebAPI.Models;


namespace _06WebAPI.Controllers
{
    public class Covid19Controller : Controller
    {
        // GET: Covid19
        //API因禁止跨域存取，先透過SERVER端接API，再接到Client端
        public async Task<ActionResult> Index()
        {
            string url = "https://covid-19.nchc.org.tw/api/covid19?CK=covid-19@nchc.org.tw&querydata=5002";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var resp = await client.GetStringAsync(url);

            var collection = JsonConvert.DeserializeObject<IEnumerable<Covid19>>(resp);
            return View(collection);
        }
    }
}