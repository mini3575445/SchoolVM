using _06WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _06WebAPI.Controllers
{
    public class TRAStationController : Controller
    {
        

        //public ActionResult Index()
        //{
        //    var accessToken = GetToken(tokenUri).Result;
        //    ViewBag.AccessToken = accessToken.access_token;

        //    var apiResponse = Get(GetParameters(), apiUri, accessToken.access_token).Result;
        //    ViewBag.ApiResponse = apiResponse;

        //    return View();
        //}

        public async Task<ActionResult> Index()
        {
             string url = "https://covid-19.nchc.org.tw/api/covid19?CK=covid-19@nchc.org.tw&querydata=5002";
             string tokenUri = $"https://tdx.transportdata.tw";
             string apiUri = $"https://tdx.transportdata.tw/api/basic/v2/Rail/TRA/LiveTrainDelay";
             string baseUrl = $"https://tdx.transportdata.tw/auth/realms/TDXConnect/protocol/openid-connect/token";

            var parameters = new Dictionary<string, string>()
            {
               { "grant_type", "client_credentials"},
                { "client_id", "jhliao-4eef97b4-71ea-4884" },
                { "client_secret", "247564cb-0dd9-4043-979d-182e5993b25a"}
            };
            var formData = new FormUrlEncodedContent(parameters);

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


            var response = await client.PostAsync(baseUrl, formData);
            var responseContent = await response.Content.ReadAsStringAsync();
            

            var Token = JsonConvert.DeserializeObject<AccessToken>(responseContent);

            var accessToken = Token;
            ViewBag.AccessToken = accessToken.access_token;
            ////////////////////////////////////////////////////////////////////////////////
            //var apiResponse = Get(GetParameters(), apiUri, accessToken.access_token).Result;

            ////////////////////////////////////
            parameters =new  Dictionary<string, string>()
            {
                { $"$select","StationName" },
                { $"$filter",""},
                { $"$orderby",""},
                { $"$top","30"},
                { $"$skip",""},
                { $"health",""},
                { $"$format","JSON"},
            };

            if (!string.IsNullOrWhiteSpace(accessToken.access_token))
            {
                client.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken.access_token}");
            }
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");

            if (parameters.Any())
            {
                var strParam = string.Join("&", parameters.Where(d => !string.IsNullOrWhiteSpace(d.Value)).Select(o => o.Key + "=" + o.Value));
                apiUri = string.Concat(apiUri, '?', strParam);
            }
            client.BaseAddress = new Uri(apiUri);

            var responseAPI = await client.GetAsync(apiUri).ConfigureAwait(false);

            var apiResponse = await responseAPI.Content.ReadAsStringAsync();



            ViewBag.ApiResponse = apiResponse;

            var resp = await client.GetStringAsync(url);
            var collection = JsonConvert.DeserializeObject<IEnumerable<TRAStation>>(resp);

            return View(collection);
            
        }

        private Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { $"$select","StationName" },
                { $"$filter",""},
                { $"$orderby",""},
                { $"$top","30"},
                { $"$skip",""},
                { $"health",""},
                { $"$format","JSON"},
            };
        }


       
    }
}