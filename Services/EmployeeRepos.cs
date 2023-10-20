using Wasly.context;
using Wasly.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wasly.net.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Wasly.net.Services
{
    public class EmployeeRepos
    {
        appcontext context /*= new appcontext()*/;
     

        public EmployeeRepos(appcontext _cont)
        {
            context = _cont;
  
        }
        public List<Order> getAllOrders() {
          return context.Orders.Where(ord=>ord.isAssigned==false).ToList();
        }

        public void setOrderEmployee(int id,string employeeId)
        {
            var order =context.Orders.FirstOrDefault(ord=>ord.Id==id);
            order.EmployeeId = employeeId;
            order.isAssigned = true;
            context.Orders.Update(order);
            context.SaveChanges();
        }
        //public void deleteOrderData(int id)
        //{
        //    Order ord = getOrderById(id);
        //    context.Orders.Remove(ord);
        //    context.SaveChanges();
        //}

    }
}
