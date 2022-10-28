using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using IconTrendsPresentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IconTrendsPresentation.Controllers
{
    public class CoongressPresidentController : Controller
    {
        string urlGetAll = "https://localhost:44320/api/CoongressPresidents/getall";
        string urlAdd = "https://localhost:44320/api/CoongressPresidents/add";
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(urlGetAll);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CongressPresident>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CongressPresident congressPresident)
        {
            var httpClient = new HttpClient();
            var jsonAnnouncement = JsonConvert.SerializeObject(congressPresident);
            StringContent content = new StringContent(jsonAnnouncement, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync(urlAdd, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CongressPresident");
            }
            return View(congressPresident);
        }

    }
}
