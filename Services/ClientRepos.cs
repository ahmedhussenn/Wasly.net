using Wasly.context;
using Wasly.net.Models;

namespace Wasly.net.Services
{
    public class ClientRepos
    {
        appcontext context /*= new appcontext()*/;
        public ClientRepos(appcontext _cont)
        {
            context = _cont;
        }

        public List<Order> Get_Orders_History(String username)
        {
         return context.Orders.Where(s=>s.ClientId==username).ToList();
        }
        public string orderStatus(int id)
        {
            Order ord = context.Orders.FirstOrDefault(s=>s.Id==id);

            if (ord != null)
            {
                return ord.Status;

            }
            return null;
        }

    }
}
