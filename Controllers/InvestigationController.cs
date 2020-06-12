using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Nemesys.Areas.Identity.Data;
using Nemesys.ViewModels;
using Microsoft.Extensions.Logging;

namespace Nemesys.Controllers
{
    public class InvestigationController : Controller
    {

        private NemesysDBContext _context;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private readonly ILogger<InvestigationController> _logger;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public InvestigationController(NemesysDBContext context, UserManager<User> userManager, SignInManager<User> signInManager, ILogger<InvestigationController> logger)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var investigation = _context.Investigation.Include(investigation => investigation.Report)
                .Include(investigation => investigation.Investigator)
                .Include(investigation => investigation.Investigator.User)
                .ToList();
            InvestigationViewModel investigationviewmodel = new InvestigationViewModel
            {
                Investigation = investigation,
                
            };
            _logger.LogInformation($"Investigations Page accessed ");
            //Console.WriteLine(investigation.ToString());
            return View(investigationviewmodel);
        }

        [HttpPost]
        public IActionResult Index(string searchS)
        {
            if (_signInManager.IsSignedIn(User))
            {

                if (searchS != null)
                {
                    var investigation = _context.Investigation.Include(investigation => investigation.Investigator)
                     .Include(investigation => investigation.Investigator.User).Include(investigation => investigation.Report).Where(r => r.Report.Title.Contains(searchS)).ToList();


                    InvestigationViewModel investigationviewmodel = new InvestigationViewModel
                    {
                        Investigation = investigation,

                    };
                    
                    return View(investigationviewmodel);
                }
                else
                {
                   var investigation = _context.Investigation.Include(investigation => investigation.Report)
                 .Include(investigation => investigation.Investigator)
                 .Include(investigation => investigation.Investigator.User)
                 .ToList();
                    InvestigationViewModel investigationviewmodel = new InvestigationViewModel
                    {
                        Investigation = investigation,

                    };
                    _logger.LogInformation($"User searched for : {searchS}  In Investigations");
                    return View(investigationviewmodel);
                }
            }
            else
            {
                _logger.LogInformation($"User attempt to access Investigation search whilst not logged in ");
                return Redirect("/Identity/Account/Login");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);
                Admin admin = _context.Admin.SingleOrDefault(c => c.User.Id == user.Id);
                Investigator investigator = _context.Investigator.SingleOrDefault(c => c.User.Id == user.Id);
                if (investigator != null || admin != null)
                {
                    Investigation investigation = _context.Investigation
                        .Include(investigation => investigation.Report)
                        .Include(investigation => investigation.Reporter)
                        .SingleOrDefault(c => c.Id == id);
                    investigator.ActiveInvestigations--;
                    investigation.Reporter.ActiveReports--;
                    investigation.Reporter.HandledReports++;
                    _logger.LogInformation($"Report  {investigation.Report.Title} Marked as complete");
                    _context.Remove(investigation.Report);
                    _context.Remove(investigation);
                    _context.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
            }
            return Unauthorized();
        }

        public async Task<IActionResult> Details(int id)
        {

            if (_signInManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);
         
                Investigator investigator = _context.Investigator.Include(investigator => investigator.User).SingleOrDefault(c => c.User.Id == user.Id);
               
                if (investigator != null)
                {

                    var investigation = _context.Investigation.Include(investigation => investigation.Report)
                                                   .Include(investigation => investigation.Reporter)
                                                       .Include(investigation => investigation.Investigator)
                                                           .Include(investigation => investigation.Reporter.User)
                                                            .Include(investigation => investigation.Investigator.User)
                                                               .SingleOrDefault(c => c.Id == id);
                    if (investigation == null)
                    {
                        return NotFound();
                    }
                    _logger.LogInformation($"User {investigation.Investigator.User.UserName}  Accessed investigation details for {investigation.Report.Title}");
                    return View(investigation);
                }
            }
            return Unauthorized();
           
        }

        public async Task<IActionResult> Assign(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);
                Report report = _context.Report.Include(report => report.Reporter).SingleOrDefault(c => c.Id == id);
                Investigator investigator = _context.Investigator.Include(investigator => investigator.User).SingleOrDefault(c => c.User.Id == user.Id);
                Investigation uniqueInvestigationCheck = _context.Investigation.SingleOrDefault(c => c.Report.Id == id);
                if (investigator != null && uniqueInvestigationCheck == null)
                {
                    Investigation investigation = new Investigation()
                    {
                        Investigator = investigator,
                        Report = report,
                        Reporter = report.Reporter,
                        StartDate = DateTime.UtcNow
                    };
                    report.Reporter.PendingReports--;
                    report.Reporter.ActiveReports++;
                    report.Status = "In Progress";
                    investigator.ActiveInvestigations++;
                    investigator.TotalInvestigations++;
                    _context.Add(investigation);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
                    return Unauthorized();
        }
        public async Task<IActionResult> MyInvestigations()
        {

            if (_signInManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);
               
                Investigator investigator = _context.Investigator.Include(investigator => investigator.User).SingleOrDefault(c => c.User.Id == user.Id);
                
                if (investigator != null )
                {
                    var investigation = _context.Investigation.Include(investigation => investigation.Report)
                                                            .Include(investigation => investigation.Investigator)
                                                                .Include(investigation => investigation.Investigator.User)
                                                                    .ToList();

                    InvestigationViewModel investigationView = new InvestigationViewModel
                    {
                        Investigation = investigation
                    };
                    _logger.LogInformation($"User {user.UserName}  Accessed My Investigations");
                    return View(investigationView);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }


        }
    }
}