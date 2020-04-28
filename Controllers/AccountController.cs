using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nemesys.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemesys.ViewModels;
using Nemesys.Models;
using Microsoft.AspNetCore.Authorization;

namespace Nemesys.Controllers
{
    public class AccountController : Controller
    {
        private  SignInManager<User> _signinManager;
        private  UserManager<User> _userManager;
        private NemesysDBContext _context;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, NemesysDBContext context)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signinManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "User name or password not correct");
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = registerViewModel.UserName
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                
                if (result.Succeeded)
                {
                    Reporter reporter = new Reporter()
                    {
                        User = user,
                        ActiveReports = 0,
                        PendingReports = 0,
                        HandledReports = 0
                    };
                    _context.Reporter.Add(reporter);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

                //If registration errors exist, show the first error one on the list
                ModelState.AddModelError("", result.Errors.First().Description);
            }

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }


    }
}