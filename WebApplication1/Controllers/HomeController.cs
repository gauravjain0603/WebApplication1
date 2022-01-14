using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult GetData()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(@"https://apc01.safelinks.protection.outlook.com/?url=https%3A%2F%2Fraw.githubusercontent.com%2FBiuni%2FPokemonGO-Pokedex%2Fmaster%2Fpokedex.json&amp;data=04%7C01%7Cgaurav.jain52%40infosys.com%7Cfb561e4306a94b00c91908d9d6a34e28%7C63ce7d592f3e42cda8ccbe764cff5eb6%7C0%7C0%7C637776819142980888%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000&amp;sdata=QuOrIOlk1kxHnuKnDH3LP%2BYeHHb5o1NpV%2Fkd%2FzqPlM4%3D&amp;reserved=0");
                return Json(json);
            }
            // return Json(json);
        }
    }
}
