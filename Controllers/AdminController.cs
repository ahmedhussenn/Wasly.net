using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wasly.net.Services;
using Wasly.net.ViewModels;

namespace Wasly.net.Controllers
{
    public class AdminController : Controller
    {
        AdminRepos AdminRepos;
        UserManager<IdentityUser> _usermanger { get; set; }
        SignInManager<IdentityUser> _SignInManager { get; set; }
        public AdminController (AdminRepos AdminRepos, UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> signInManager)
        {
            this.AdminRepos = AdminRepos;

            _usermanger = UserManager;
            _SignInManager = signInManager;
        }
        public IActionResult Index()
        {
            UserName_And_Role u = new UserName_And_Role();
            return View("Index",u);
        }
        
        public IActionResult SearchForAccount(string Name)
        {
            return View("Index", AdminRepos.GetuserRole(Name));
        }
        
        public IActionResult addEmployee()
        {
            return View();
        }
        
         public IActionResult deleteAcc(string id)
        {
            AdminRepos.deleteAccount(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> insertEmployee(Registeraccountmodel newaccount)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = newaccount.username;
            //Ahmed123!

            if (ModelState.IsValid == true)
            {
                IdentityResult res = await _usermanger.CreateAsync(user, newaccount.password);
                if (res.Succeeded)
                {

                    //  await _SignInManager.SignInAsync(user,true);//kam youm
                    await _usermanger.AddToRoleAsync(user, "Employee");
                    await _SignInManager.SignInAsync(user, false);//per session
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    foreach (var error in res.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View("addEmployee");
                }
            }
            return View("Register", newaccount);
        }
    }
}
