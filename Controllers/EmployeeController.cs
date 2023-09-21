using Microsoft.AspNetCore.Mvc;

namespace Wasly.net.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
