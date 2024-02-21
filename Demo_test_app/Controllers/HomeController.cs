using Demo_test_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo_test_app.Controllers
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
        public IActionResult Authorize()
        {
            return View();
        }
        public IActionResult ApplicationList()
        {
            return View();
        }
        public IActionResult ApplicationEdit()
        {
            return View();
        }
        public IActionResult ApplicationEditemployee()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
