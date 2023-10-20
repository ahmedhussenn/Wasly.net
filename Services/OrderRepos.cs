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

        public Order getOrderById(int id)
        {
            Order ord = context.Orders.FirstOrDefault(o => o.Id == id);
            return ord;
        }

        public OrderRepos(appcontext _cont)
        {
            context = _cont;
        }

        public void Add_Order(Order neworder)
        {
            context.Add(neworder);  
            context.SaveChanges();  
        }
        public void deleteOrderData(int id)
        {
            Order ord = getOrderById(id);
            context.Orders.Remove(ord);
            context.SaveChanges();
        }
        public void Edit_Order(Order newOrder)
        {
            Order oldOrder = getOrderById(newOrder.Id);
            if (oldOrder != null)
            {
                oldOrder.Id = newOrder.Id;
                oldOrder.Name = newOrder.Name;
                oldOrder.Description = newOrder.Description;
                oldOrder.Pickup_Address = newOrder.Pickup_Address;
                oldOrder.Destination_Address = newOrder.Destination_Address;
                oldOrder.Released_Date = newOrder.Released_Date;
                oldOrder.Delivered_Date = newOrder.Delivered_Date;
                oldOrder.ClientId = newOrder.ClientId;
                oldOrder.EmployeeId = newOrder.EmployeeId;
                context.Orders.Update(oldOrder);
            }
            context.SaveChanges();
        }

    }
}
