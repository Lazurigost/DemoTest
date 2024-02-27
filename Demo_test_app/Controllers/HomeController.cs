using Demo_test_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Demo_test_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ZayavkerBackContext _context;

        public HomeController(ILogger<HomeController> logger, ZayavkerBackContext context)
        {
            _logger = logger;
            _context = context;
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
        public async Task<IActionResult> ApplicationList()
        {
            return View(await _context.Applications.ToListAsync());
        }
        public IActionResult ApplicationEdit(int id)
        {
            return View(id);
        }
        public IActionResult ApplicationEditemployee()
        {
            return View();
        }
        public IActionResult ApplicationAdd()
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
