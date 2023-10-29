using Microsoft.AspNetCore.Mvc;
using Wasly.net.Services;

namespace Wasly.net.Controllers
{
    public class ClientController : Controller
    {
        ClientRepos clientrepos;
        public ClientController(ClientRepos _clientrepos)
        {
            this.clientrepos = _clientrepos;
        }
        public IActionResult HomePage()
        {
    
            return View("HomePage");
        }

        public IActionResult RequestHistory()
        {
            
            return View("RequestHistory", clientrepos.Get_Orders_History(HttpContext.Session.GetString("Username")));
        }
        
        public IActionResult orderFollowUp(int id)
        {
            string ordStats =  clientrepos.orderStatus(id);
            return View("orderFollowUp", ordStats);
        }
    }
}
