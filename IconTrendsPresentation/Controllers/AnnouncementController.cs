
using IconTrendsPresentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IconTrendsPresentation.Controllers
{
    public class AnnouncementController : Controller
    {
        string urlGetAll = "https://localhost:44320/api/Announcements/getall";
        string urlAdd = "https://localhost:44320/api/Announcements/add";
        string urlDelete = "https://localhost:44320/api/Announcements/delete";

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(urlGetAll);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Announcement>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Announcement announcement)
        {
            var httpClient = new HttpClient();
            var jsonAnnouncement = JsonConvert.SerializeObject(announcement);
            StringContent content = new StringContent(jsonAnnouncement,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync(urlAdd,content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Announcement");
            }
            return View(announcement);
        }

        public async Task<IActionResult> DeleteAnnounce(Announcement announcement)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync(urlDelete);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Announcement");
            }
            else
            {
                return RedirectToAction("Index","Congress");
            }
           // return View();
        }

    }
}
