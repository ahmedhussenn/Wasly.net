using Wasly.context;
using Wasly.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wasly.net.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Wasly.net.Services;
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
        public List<Order> getAllOrdersOfEmployee(string _EmployeeId)
        {
            if (_EmployeeId != null)
                return context.Orders.Where(ord => ord.EmployeeId.Equals(_EmployeeId)).ToList();
            else
                return null;
        }

        public void setOrderEmployee(int id,string employeeId)
        {
            var order =context.Orders.FirstOrDefault(ord=>ord.Id==id);
            order.EmployeeId = employeeId;
            order.isAssigned = true;
            order.Status = "Your Order Is Picked...!!!";
            context.Orders.Update(order);
            context.SaveChanges();
        }
        public void deliverOrder(int id, string employeeId)
        {
            var order = context.Orders.FirstOrDefault(ord => ord.Id == id);
            order.Status = "Your Order Is Delivered...!!!";
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
