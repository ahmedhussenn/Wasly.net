using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wasly.net.Models;
using Wasly.net.Services;

namespace Wasly.net.Controllers
{
    [Authorize(Roles = "Client")]
    public class OrderController : Controller
    {
        OrderRepos orderRepos;
        public OrderController(OrderRepos _orderrepos)
        {
            this.orderRepos = _orderrepos;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Request_Order()
        {
            return View("Request_Order");
        }

        [HttpPost]
        public IActionResult Request_Order(Order neworder)
        {
            neworder.ClientId=HttpContext.Session.GetString("Username");
            orderRepos.Add_Order(neworder); 
            return RedirectToAction("Index", "Home");
        }
    }
}
