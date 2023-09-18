using Wasly.context;
using Wasly.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wasly.net.Models;
using System.Security.Claims;
namespace Wasly.net.Services
{
    public class OrderRepos
    {
        appcontext context /*= new appcontext()*/;
        public OrderRepos(appcontext _cont)
        {
            context = _cont;
        }

        public void Add_Order(Order neworder)
        {
            context.Add(neworder);  
            context.SaveChanges();  
        }
     
    }
}
