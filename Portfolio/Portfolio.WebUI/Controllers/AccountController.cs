using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio.Application.Core.Extension;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities.Membership;
using Portfolio.Domain.Models.FormModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly UserManager<PortfolioUser> userManager;
        readonly SignInManager<PortfolioUser> signInManager;
        readonly PortfolioDbContext db;
        readonly IConfiguration configuration;

        public AccountController(UserManager<PortfolioUser> userManager, SignInManager<PortfolioUser> signInManager, PortfolioDbContext db, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.db = db;
        }


        public IActionResult Signin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Signin(LoginFormModel model)
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

                if (!await userManager.IsInRoleAsync(found, "User"))
                {
                    ViewBag.Message = "Username or Password is incorrect";
                    return View(model);
                }
                var isconfirmed = await db.Users.FirstOrDefaultAsync(u => u.UserName.Equals(model.UserName) && u.EmailConfirmed != true);
                if (isconfirmed != null)
                {
                    ViewBag.Message = "Go confirm your email first!";
                    return View(model);
                }

                var signInResult = await signInManager.PasswordSignInAsync(found, model.Password, false, true);
                if (!signInResult.Succeeded)
                {
                    ViewBag.Message = "Username or Password is incorrect";
                    return View(model);
                }

              /*  var redirectUrl = Request.Query["ReturnUrl"];

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                {
                    return Redirect(redirectUrl);
                }*/

                return RedirectToAction("index", "Home");
            }
            ViewBag.Message = "Fill the required fields!";
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("signin");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new PortfolioUser();

                user.UserName = model.UserName;
                user.Email = model.Email;

                if (model.Password != model.PasswordCheck)
                {
                    ViewBag.Message = "Passwords are different!";
                    return View(model);
                }
                var iUserResult = userManager.CreateAsync(user, model.Password).Result;
                foreach (var item in iUserResult.Errors)
                {
                    if (item.Code.Contains("DuplicateUserName"))
                    {
                        ViewBag.Message = "Username is already taken!";
                        return View(model);
                    }
                    else if (item.Code.Contains("DuplicateEmail"))
                    {
                        ViewBag.Message = "Email is already taken!";
                        return View(model);
                    }
                }
                /* string token = $"subscribetoken-{model.UserName}-{DateTime.Now:yyyyMMddHHmmss}";

                 string chiperToken = token.Encrypt("Riode");

                */

                if (iUserResult.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    string path = $"{Request.Scheme}://{Request.Host}/register-email-confirm?token={token}&UserName={model.UserName}";

                    var mailSent = configuration.SendEmail(model.Email, "Riode Newsletter Subscription", $"Please confirm your Email through this <a href={path}>link</a>");

                    userManager.AddToRoleAsync(user, "User").Wait();
                }

                return RedirectToAction("EmailConfrimationNotice", "Account");
            }
            ViewBag.Message = "Fill the required fields!";
            return View(model);
        }

        [HttpGet]
        [Route("register-email-confirm")]
        public IActionResult RegisterConfirm(string token,string username)
        {
            if (token != null)
            {
                var subscribe = db.Users.FirstOrDefault(s => s.UserName ==username);

                if (subscribe == null)
                {
                    ViewBag.message = Tuple.Create(true, "Token Error");
                    goto end;
                }

                if (subscribe.EmailConfirmed == true)
                {
                    ViewBag.message = Tuple.Create(true, "Already Confirmed");
                    goto end;
                }

                subscribe.EmailConfirmed = true;
                db.SaveChanges();

                ViewBag.message = Tuple.Create(false, "Succesfully Confirmed");
            }
        end:
            return View();
        }
        public IActionResult EmailConfrimationNotice()
        {
            return View();
        }
    }
}
