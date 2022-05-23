using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInManager { get; }

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInManager)
        {
            UserMgr = userMgr;
            SignInManager = signInManager;
        }


        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.message = "User already registered";

                AppUser user = await UserMgr.FindByNameAsync("TestUser2");
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = "TestUser2";
                    user.Email = "Teest.test";
                    user.FirstName = "Jan";
                    user.LastName = "Kowalski";


                    IdentityResult result = await UserMgr.CreateAsync(user, "Test12");

                    var errorList = result.Errors.ToList();
                    ViewBag.message = string.Join(" ", errorList.Select(e => e.Description));


                }
            }
            catch(Exception ex)
            {

                ViewBag.message = ex.Message;

            }

            return View();
        }
        public async Task<IActionResult> Login()
        {
            var result = await SignInManager.PasswordSignInAsync("TestUser", "Test123!", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.result = result.ToString();
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
