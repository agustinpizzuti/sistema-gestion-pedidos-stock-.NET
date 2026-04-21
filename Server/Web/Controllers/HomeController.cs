using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string mensaje)
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                ViewBag.mensaje = mensaje;
                return View();
            }
            else 
            {
                return RedirectToAction("Index", "Error");
            }
            
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Index", "Error");
            }
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
