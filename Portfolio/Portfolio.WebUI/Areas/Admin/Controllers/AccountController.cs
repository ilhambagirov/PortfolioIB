using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Core.Extension;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities.Membership;
using Portfolio.Domain.Models.FormModels;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        readonly UserManager<PortfolioUser> userManager;
        readonly SignInManager<PortfolioUser> signInManager;
        readonly PortfolioDbContext db;
        public AccountController(UserManager<PortfolioUser> userManager, SignInManager<PortfolioUser> signInManager, PortfolioDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (ModelState.IsValid)
            {
                PortfolioUser found = null;
                if (model.UserName.IsEmail())
                {
                    found = await userManager.FindByEmailAsync(model.UserName);
                }
                else
                {
                    found = await userManager.FindByNameAsync(model.UserName);
                }

                if (found == null)
                {
                    ViewBag.Message = "Username or Password is incorrect";
                    return View(model);
                }

                var rIds = db.UserRoles.Where(ur => ur.UserId == found.Id).Select(ur => ur.RoleId).ToArray();

                var otherRoles = db.Roles.Where(r => !r.NormalizedName.Equals("User") && rIds.Contains(r.Id)).Any();

                if (otherRoles == false)
                {
                    ViewBag.Message = "Username or Password is incorrect";
                    return View(model);
                }

                var signInResult = await signInManager.PasswordSignInAsync(found, model.Password, false, true);
                if (!signInResult.Succeeded)
                {
                    ViewBag.Message = "Username or Password is incorrect";
                    return View(model);
                }

                return RedirectToAction("index", "Dashboard");
            }
            ViewBag.Message = "Fill the required fields!";
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}
