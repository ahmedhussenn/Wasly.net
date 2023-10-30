using Wasly.context;
using Wasly.net.ViewModels;

namespace Wasly.net.Services
{
    public class AdminRepos
    {

        appcontext context;
        Registeraccountmodel registeraccountmodel = new Registeraccountmodel();
        public AdminRepos(appcontext _cont)
        {
            context = _cont;
        }
        public UserName_And_Role Getusers(string Name)
        {

            var query = (from userRole in context.UserRoles
                         join user in context.Users on userRole.UserId equals user.Id
                         join role in context.Roles on userRole.RoleId equals role.Id
                         where user.UserName == Name
                         select new
                         {
                             Role = role.Name, 
                             username = user.UserName,
                         }).FirstOrDefault();

            if (query != null)
            {
                UserName_And_Role u = new UserName_And_Role() { username = query.username, Role = query.Role };
                return u;
            }
            return null;
        }
        

        }
     
    }

