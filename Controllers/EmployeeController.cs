using Microsoft.AspNetCore.Mvc;
using Wasly.net.Services;

namespace Wasly.net.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepos employeerepos;
        public EmployeeController(EmployeeRepos _employeerepos)
        {
            this.employeerepos = _employeerepos;
        }
        public IActionResult Index()
        {
            // Retrieve userRole from TempData
            var userRole = TempData["userRole"] as string;
            return View("Index",employeerepos.getAllOrders());
        }
        public IActionResult addOrderToEmployee(int id)
        {
            string empId = HttpContext.Session.GetString("Username");
            employeerepos.setOrderEmployee(id,empId);
            return View("Index", employeerepos.getAllOrders());
        }
        public IActionResult showOrders()
        {
            string empId = HttpContext.Session.GetString("Username");
            return View("showOrders" , employeerepos.getAllOrdersOfEmployee(empId));
        }
        
        public IActionResult deliverTheOrder(int id)
        {
            string empId = HttpContext.Session.GetString("Username");
            employeerepos.deliverOrder(id, empId);
            return View("Index", employeerepos.getAllOrders());
        }
    }
}
