using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nemesys.Areas.Identity.Data;
using Nemesys.Models;
using Nemesys.ViewModels;
using System.Web;

namespace Nemesys.Controllers
{
    public class AdminController : Controller
    {
        private SignInManager<User> _signinManager;
        private UserManager<User> _userManager;
        private NemesysDBContext _context;
        public AdminController(SignInManager<User> signInManager, UserManager<User> userManager, NemesysDBContext context)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            if (_signinManager.IsSignedIn(User))
            {
                
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var admin = _context.Admin.SingleOrDefault(c => c.User.Id == userId);
                if (admin != null)
                {
                    return View();
                }
                
            }
            
                return NotFound();
            
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreate create)
        {

            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = create.UserName
                };

                var result = await _userManager.CreateAsync(user, "P@ssword123");

                if (result.Succeeded)
                {
                    

                    if (create.UserType == "Reporter")
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
                    }
                    else if(create.UserType == "Investigator")
                    {
                        Investigator investigator = new Investigator    ()
                        {
                            User = user,
                            ActiveInvestigations = 0,
                            TotalInvestigations = 0,
                            
                        };
                        _context.Investigator.Add(investigator);
                        _context.SaveChanges();
                    }
                    else if (create.UserType == "Administrator")
                    {
                        Admin admin = new Admin()
                        {
                            User = user,
                            

                        };
                        _context.Admin.Add(admin);
                        _context.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("", result.Errors.First().Description);
                    }


                    return RedirectToAction("Index", "Home");
                }

                //If registration errors exist, show the first error one on the list
                ModelState.AddModelError("", result.Errors.First().Description);
            }

            return View(create);
        }
    }
}