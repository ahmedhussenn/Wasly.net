using Microsoft.AspNetCore.Mvc;
using Wasly.net.Services;

namespace Wasly.net.Controllers
{
    public class AdminController : Controller
    {
        AdminRepos AdminRepos;

        public AdminController (AdminRepos AdminRepos)
        {
            this.AdminRepos = AdminRepos;
        }
        public IActionResult Index()
        {
            return View("Index",AdminRepos.Getusers("admin"));
        }
    }
}
