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

                    var report = _context.Report.Include(report => report.Reporter)
                        .Include(report => report.Reporter.User)
                        .OrderByDescending(c => c.Date)
                        .ToList();
                    var investigation = _context.Investigation.Include(investigation => investigation.Investigator)
                        .Include(investigation => investigation.Investigator.User)
                        .OrderByDescending(c => c.StartDate)
                        .ToList();
                    AdminIndex adminIndex = new AdminIndex()
                    {
                        Reports = report,
                        Investigations = investigation
                    };
                    return View(adminIndex);
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
                    UserName = create.UserName,
                    Email = create.UserName

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
                    else if (create.UserType == "Investigator")
                    {
                        Investigator investigator = new Investigator()
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
        [HttpGet]
        public async Task<IActionResult> Assign(int id)
        {
            if (_signinManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);

                Admin admin = _context.Admin.SingleOrDefault(c => c.User.Id == user.Id);
                if (admin != null)
                {
                    Report report = _context.Report.SingleOrDefault(c => c.Id == id);
                    var investigators = _context.Investigator.Include(investigators => investigators.User).ToList();
                    AdminAssign adminAssign = new AdminAssign()
                    {
                        report = report,
                        Investigators = investigators
                    };
                    return View(adminAssign);
                }
            }
            return Unauthorized();
        }

        [Route("Admin/Assign/{reportid}/{investigatorid}")]
        
        public async Task<IActionResult> Assign(int reportid, int investigatorid)
        {
            if (_signinManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);

                Admin admin = _context.Admin.SingleOrDefault(c => c.User.Id == user.Id);
                if (admin != null)
                {
                    Report report = _context.Report.Include(report => report.Reporter).SingleOrDefault(c => c.Id == reportid);
                    Investigator investigator = _context.Investigator.SingleOrDefault(c => c.Id == investigatorid);

                    if(report != null && investigator != null)
                    {
                        Investigation investigation = new Investigation()
                        {
                            Report = report,
                            Investigator = investigator,
                            StartDate = DateTime.UtcNow,
                            Reporter = report.Reporter                            
                        };
                        _context.Add(investigation);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }

                    
            
            return Unauthorized();

        }
    }
}