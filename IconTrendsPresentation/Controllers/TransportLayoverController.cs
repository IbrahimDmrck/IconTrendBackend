using IconTrendsPresentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IconTrendsPresentation.Controllers
{
    public class TransportLayoverController : Controller
    {
        string url = "https://localhost:44320/api/TransportLayovers/getall";

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage =await httpClient.GetAsync(url);
            var jsonString =await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TransportLayover>>(jsonString);
            return View(values);
        }
    }
}
