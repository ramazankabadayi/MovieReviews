using Microsoft.AspNetCore.Mvc;
using MovieReviewsBL;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private readonly FilmManager _filmManager;

        public HomeController(FilmManager filmManager)
        {
            _filmManager = filmManager;
        }

        public IActionResult Index()
        {
            var films = _filmManager.GetAllData();
            return View(films);
        }
    }
}
