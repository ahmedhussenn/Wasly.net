using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wasly.net.Models;
using System.Security.Claims;



namespace Wasly.net.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        String usernamehold;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //ok
        public IActionResult Index()
        {
            //   var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

             usernamehold = HttpContext.Session.GetString("Username");
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
    }
}