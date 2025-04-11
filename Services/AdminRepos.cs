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
        public UserName_And_Role GetuserRole(string Name)
        {
            string normalizedQuery = Name?.Replace(" ", "").ToLower();
            var query = (from userRole in context.UserRoles
                         join user in context.Users on userRole.UserId equals user.Id
                         join role in context.Roles on userRole.RoleId equals role.Id
                         where user.UserName.ToLower() == normalizedQuery
                         select new
                         {
                             Role = role.Name, 
                             username = user.UserName,
                             userId = user.Id
                         }).FirstOrDefault();

            if (query != null &&query.Role!=null)
            {
                UserName_And_Role u = new UserName_And_Role() { userId = query.userId,username = query.username, Role = query.Role };
                return u;
            }
            return new UserName_And_Role();
        }
        public void deleteAccount(string id)
        {
            context.Users.Remove(context.Users.FirstOrDefault(u => u.Id == id));
            context.SaveChanges();
        }


    }
     
    }

