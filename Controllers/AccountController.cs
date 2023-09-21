using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wasly.net.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace Wasly.net.Controllers
{
    public class AccountController : Controller
    {
       
        UserManager<IdentityUser> _usermanger { get; set; }
        SignInManager<IdentityUser> _SignInManager { get; set; }
        public AccountController(UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> signInManager)
        {
            _usermanger = UserManager;
            _SignInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(Registeraccountmodel newaccount)
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
                    await _usermanger.AddToRoleAsync(user, "Client");
                    await _SignInManager.SignInAsync(user, false);//per session
                }
                else
                {
                    foreach (var error in res.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View("Register");
                }
            }
            return View("Register", newaccount);
        }


        public IActionResult Login(String ReturnUrl = "~/Client/Homepage")
        {
            ViewData["RedirectUrl"] = ReturnUrl;
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginuser, String ReturnUrl)
        {


            if (ModelState.IsValid == true)
            {
                IdentityUser user = await _usermanger.FindByNameAsync(loginuser.username);
     
                if (user != null)
                {
                    SignInResult result = await _SignInManager.PasswordSignInAsync(user, loginuser.password, true, false);
                    if (result.Succeeded)
                    {
                   
                        HttpContext.Session.SetString("Username", user.Id);
     
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {

                        ModelState.AddModelError("", "invalid user name and password");
                        return View("Login");
                    }
                }

                else
                {

                    ModelState.AddModelError("", "invalid user name and password");
                    return View("Login");
                }
            }
            return View("Login", loginuser);
        }

        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return View("Login");
        }


        public IActionResult Addadmin()
        {
            return View("View");
        }
        [HttpPost]
        public async Task<IActionResult> Addadmin(Registeraccountmodel newaccount)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = newaccount.username;


            if (ModelState.IsValid == true)
            {
                IdentityResult res = await _usermanger.CreateAsync(user, newaccount.password);
                if (res.Succeeded)
                {
                    //  await _SignInManager.SignInAsync(user,true);//kam youm
                    await _usermanger.AddToRoleAsync(user, "Admin");
                    await _SignInManager.SignInAsync(user, false);//per session
                }
                else
                {
                    foreach (var error in res.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View("View");
                }
            }
            return View("View", newaccount);
        }



    

        public IActionResult Index()
        {
            return View();
        }
    }
}
