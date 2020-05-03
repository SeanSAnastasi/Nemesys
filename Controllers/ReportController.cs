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

namespace Nemesys.Controllers
{
    public class ReportController : Controller
    {
        private NemesysDBContext _context;
        private  SignInManager<User> _signInManager;
        private  UserManager<User> _userManager;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ReportController(NemesysDBContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            
            var report = _context.Report.Include(report => report.Reporter).Include(report => report.Reporter.User).ToList();
            
            return View(report);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var report = _context.Report.Include(report => report.Reporter).SingleOrDefault(c => c.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }
        public async Task<IActionResult> Delete(int id)
        {

            if (_signInManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);
                Report report = _context.Report.Include(report => report.Reporter).Include(report => report.Reporter.User).SingleOrDefault(c => c.Id == id);
                Admin admin = _context.Admin.SingleOrDefault(c => c.User.Id == user.Id);
                Investigation investigation = _context.Investigation.SingleOrDefault(c => c.Report.Id == id);
                
                if (report.Reporter.User.Id == user.Id || admin != null)
                {
                    if(investigation == null)
                    {
                        report.Reporter.PendingReports--;
                    }
                    else
                    {
                        _context.Investigation.Remove(investigation);
                        report.Reporter.ActiveReports--;
                    }
                    _context.Report.Remove(report);
                    _context.SaveChanges();
                }

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = await _userManager.GetUserAsync(User);
                Report report = _context.Report.Include(report => report.Reporter).Include(report => report.Reporter.User).SingleOrDefault(c => c.Id == id);
                Admin admin = _context.Admin.SingleOrDefault(c => c.User.Id == user.Id);
                if (report.Reporter.User.Id == user.Id || admin != null)
                {
                    ReportViewModel reportModel = new ReportViewModel()
                    {
                        Title = report.Title,
                        Description = report.Description,
                        Location = report.Location

                    };
                    return View(reportModel);
                }
            }

            return Unauthorized();
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Title", "Date", "HazardType", "Status", "Location", "Description", "ImageLocation", "Likes")] ReportViewModel editReport)
        {
            /*  if (ModelState.IsValid)
              {
                  string file = "";
                  if(newReport.)
              }*/
            if (_signInManager.IsSignedIn(User))
            {


                User user = await _userManager.GetUserAsync(User);
                Report report = _context.Report.Include(report => report.Reporter).Include(report => report.Reporter.User).SingleOrDefault(c => c.Id == id);
                Admin admin = _context.Admin.SingleOrDefault(c => c.User.Id == user.Id);
                if (report.Reporter.User.Id == user.Id || admin != null)
                {
                    report.Title = editReport.Title;
                    report.Description = editReport.Description;
                    report.Location = editReport.Location;

                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       



        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title","Date","HazardType","Status","Location","Details","ImageLocation","Likes")] CreateReport newReport)
        {
            /*  if (ModelState.IsValid)
              {
                  string file = "";
                  if(newReport.)
              }*/
            if (_signInManager.IsSignedIn(User))
            {

            
            User user = await _userManager.GetUserAsync(User);
            Reporter reporter = _context.Reporter.SingleOrDefault(c => c.User.Id == user.Id);
            if(reporter != null){
                Report report = new Report()
                {

                    Title = newReport.Title,
                    Date = DateTime.UtcNow,
                    //ImageLocation = newReport.ImageLocation,
                    Status = "In Progress",
                    Description = newReport.Details,
                    Location = newReport.Location,
                    HazardType = newReport.HazardType,
                    Reporter = reporter,
                    Likes = 0

                };
                reporter.PendingReports++;
                _context.Report.Add(report);
                _context.SaveChanges();
            }
            }
            return RedirectToAction("Index");
            
        }

    }
}