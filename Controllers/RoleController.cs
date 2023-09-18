using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Wasly.net.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> rolemanager;

        public RoleController(RoleManager<IdentityRole> _rolemanager)
        {
            rolemanager = _rolemanager;
        }
        public async Task<IActionResult> index()
        {
            IdentityRole role = new IdentityRole() { Name ="Client" };
            IdentityResult res = await rolemanager.CreateAsync(role);

            if (res.Succeeded)
            {
                return Content("Role succesfuly created");

            }
            else
            {
                foreach (var error in res.Errors)
                    ModelState.AddModelError("", error.Description);
                return View("roleview");
            }
        }

    
    }
}
