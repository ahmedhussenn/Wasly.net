using Wasly.context;
using Wasly.net.Models;

namespace Wasly.net.Services
{
    public class AccountRepos
    {
        appcontext context /*= new appcontext()*/;
        public AccountRepos(appcontext _cont)
        {
            context = _cont;
        }
        public bool getEmployeeRole(string id)
        {
            var role = context.UserRoles.FirstOrDefault(x => x.UserId == id);
            if (role.RoleId == "Employee_id")
            { 
            return true;
            }
        
            return false;
           
        }
        //admin
        public bool getAdminRole(string id)
        {
            var role = context.UserRoles.FirstOrDefault(x => x.UserId == id);
            if (role.RoleId == "Admin_id")
            {
                return true;
            }
            return false;

        }



        }
}
