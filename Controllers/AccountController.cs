using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wasly.net.Services;
using Wasly.net.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace Wasly.net.Controllers
{
    public class AccountController : Controller
    {
        AccountRepos _accountrepos;
        UserManager<IdentityUser> _usermanger { get; set; }
        SignInManager<IdentityUser> _SignInManager { get; set; }
        public AccountController(UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> signInManager, AccountRepos accountrepos)
        {
            _usermanger = UserManager;
            _SignInManager = signInManager;
            _accountrepos = accountrepos;
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
                    return RedirectToAction("Login","Account");
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
            ViewBag.ReturnUrl = ReturnUrl;
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginuser, String ReturnUrl)
        {

            if (ReturnUrl == null)
            {
                ReturnUrl = "~/Client/Homepage";
              
            }
            if (ModelState.IsValid == true)
            {
                IdentityUser user = await _usermanger.FindByNameAsync(loginuser.username);
     
                if (user != null)
                {
                    SignInResult result = await _SignInManager.PasswordSignInAsync(user, loginuser.password, true, false);
                    if (result.Succeeded)
                    {
                        ViewData["userId"] = user.Id; 
                        if (_accountrepos.getAccountRole(user.Id))
                        {
                            ViewData["userRole"] = "Employee";
                            HttpContext.Session.SetString("Username", user.Id);
                            return RedirectToAction("Index", "Employee");
                        }
                   
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
            return RedirectToAction("Login");
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



        [HttpGet]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                // Handle errors from the external provider, if any.
                // You can redirect to an error page or take appropriate action.
                return Content("nooo");
            }

            var info = await _SignInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {

                return Content("nooo");
            }


            string email = info.Principal.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
            {

                return Content("nooo");
            }


            var signInResult = await _SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
  

                // Get the user's ID from the ClaimsPrincipal
                IdentityUser userr = await _usermanger.FindByNameAsync(email);

                HttpContext.Session.SetString("Username", userr.Id);
             
                return RedirectToAction("HomePage", "Client") ;
            }



            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _usermanger.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await _usermanger.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _usermanger.AddToRoleAsync(user, "Client");
                    await _SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("HomePage", "Client");
                }
            }

 


            ViewData["ReturnUrl"] = returnUrl;
            return Content("failed");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
