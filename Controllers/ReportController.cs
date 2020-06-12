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
using System.IO;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Nemesys.Controllers
{
    public class ReportController : Controller
    {
        private NemesysDBContext _context;
        private  SignInManager<User> _signInManager;
        private  UserManager<User> _userManager;
        private readonly ILogger<ReportController> _logger;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        

        public ReportController(NemesysDBContext context, UserManager<User> userManager, SignInManager<User> signInManager, ILogger<ReportController> logger)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;


        }
        [HttpGet]
        public IActionResult Index()
        {

            if (_signInManager.IsSignedIn(User))
            {

                var report = _context.Report.Include(report => report.Reporter)
                .Include(report => report.Reporter.User).ToList();

                ReportIndexViewModel reportIndex = new ReportIndexViewModel
                {
                    Report = report
                };

                return View(reportIndex);
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

            
        }

        [HttpPost]
        public IActionResult Index(string searchS)
        {
            if (_signInManager.IsSignedIn(User))
            {

                if (searchS != null)
                {
                    var report = _context.Report.Include(report => report.Reporter)
                     .Include(report => report.Reporter.User).Where(r => r.Title.Contains(searchS)).ToList();


                    ReportIndexViewModel reportIndex = new ReportIndexViewModel
                    {
                        Report = report
                    };
                    _logger.LogInformation($"User Searched for {searchS}");
                    return View(reportIndex);
                }
                else
                {
                    var report = _context.Report.Include(report => report.Reporter)
                    .Include(report => report.Reporter.User).ToList();

                    ReportIndexViewModel reportIndex = new ReportIndexViewModel
                    {
                        Report = report
                    };
                    _logger.LogInformation($"User Search query was null");
                    return View(reportIndex);
                }
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

         
            
                

            
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {

                var report = _context.Report
                    .Include(report => report.Reporter)
                         .Include(report => report.Reporter.User)
                             .SingleOrDefault(c => c.Id == id);
                if (report == null)
                {
                    return NotFound();
                }
                return View(report);
            }
            else
            {
                _logger.LogInformation($"User tryed to access page without loging in" );
                return Redirect("/Identity/Account/Login");
            }

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
                    _logger.LogInformation($"successfully deleted report: {report.Title}");
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
                        Location = report.Location,
                        HazardType = report.HazardType


                    };
                    return View(reportModel);
                }
            }
            return Unauthorized();
        }
        
        public async Task<IActionResult> Like( int id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                
                    var report = _context.Report.SingleOrDefault(d => d.Id == id);

                    User user = await _userManager.GetUserAsync(User);
                    Reporter reporter = _context.Reporter.Include(reporter => reporter.User).SingleOrDefault(d => d.User.Id == user.Id);

                    if (reporter != null)
                    {
                        var Like = _context.Like.
                            Include(Like => Like.Reporter)
                                 .Include(Like => Like.Report)
                                    .SingleOrDefault(c => (c.Reporter == reporter && c.Report == report));

                    if (Like == null) // No no exist
                    {
                        Like newLike = new Like()
                        {
                            Report = report,
                            Reporter = reporter
                        };
                         report.Likes++;
                        _context.Like.Add(newLike);
                        _context.SaveChanges();
                    
                        }
                        else
                        {
                           
                         report.Likes--;
                        _context.Like.Remove(Like);
                         _context.SaveChanges();
                        
                        }

                    }

                    /*    var Like = _context.Like
                          .Include(Like => Like.Reporter)
                              .Include(Like => Like.Report)
                                  .SingleOrDefault(c => c.Id == id); */


                    return RedirectToAction("Index");
                
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
                    report.HazardType = editReport.HazardType;

                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Create()
        {
            if (_signInManager.IsSignedIn(User))
            {
                CreateReport report = new CreateReport();
                return View(report);
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
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
                if (ModelState.IsValid)
                {
                    var fullpath = "";
                    try
                    {
                        var fName = "";
                        var thispath = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\repo\\";
                        if (newReport.ImageLocation != null)
                        {
                            fName = Path.GetFileNameWithoutExtension(newReport.ImageLocation.FileName);
                        }
                        else
                        {
                            fName = "0";
                        }
                        if (fName != "0")
                        {
                            var ext = Path.GetExtension(newReport.ImageLocation.FileName);
                            //make unique
                            fullpath = DateTime.Now.ToString("MMyyyyddss") + fName + ext; // seperate to make it easy to change order if needed
                            var custfullpath = thispath + fullpath;                                                  // fullpath into bits
                            using (var bits = new FileStream(custfullpath, FileMode.Create))
                            {
                                await newReport.ImageLocation.CopyToAsync(bits);
                            }
                            Console.WriteLine(fullpath);
                        }
                        else
                        {
                            fullpath = null;
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"Exception thrown :  {e}");
                    }


                    // var bits = new FileStream(thispath,s FileMode.Create);

                    User user = await _userManager.GetUserAsync(User);
                    Reporter reporter = _context.Reporter.SingleOrDefault(c => c.User.Id == user.Id);


                    if (reporter != null)
                    {

                        if (fullpath != null)
                        {
                            Report report = new Report()
                            {

                                Title = newReport.Title,
                                Date = DateTime.UtcNow,
                                ImageLocation = "/images/repo/" + fullpath,
                                Status = "In Progress",
                                Description = newReport.Details,
                                Location = newReport.Location,
                                HazardType = newReport.HazardType,
                                Reporter = reporter,
                                Likes = 0

                            };
                            Console.WriteLine(newReport.HazardType);
                            reporter.PendingReports++;
                            _context.Report.Add(report);
                            _context.SaveChanges();
                            _logger.LogInformation($"Successfully created new report {report.Title}");
                        }
                        else
                        {
                            Report report = new Report()
                            {

                                Title = newReport.Title,
                                Date = DateTime.UtcNow,
                                ImageLocation = null,
                                Status = "Open",
                                Description = newReport.Details,
                                Location = newReport.Location,
                                HazardType = newReport.HazardType,
                                Reporter = reporter,
                                Likes = 0
                            };
                            _logger.LogInformation($"Successfully created new report {report.Title}");
                            Console.WriteLine(newReport.HazardType);
                            reporter.PendingReports++;
                            _context.Report.Add(report);
                            _context.SaveChanges();
                        }

                    }
                }
                else
                {
                    return View(newReport);
                }
                

            }
      
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> MyReports()
        {
            try
            {
                if (_signInManager.IsSignedIn(User))
                {
                    User user = await _userManager.GetUserAsync(User);
                    
                    var report = _context.Report.Include(report => report.Reporter)
                    .Include(report => report.Reporter.User).Where(report => report.Reporter.User == user).ToList();

                    ReportIndexViewModel reportIndex = new ReportIndexViewModel
                    {
                        Report = report
                    };
                    _logger.LogInformation($"User {user} accessed - My reports page");
                    return View(reportIndex);
                }
                else
                {
                    return Redirect("/Identity/Account/Login");
                }

            }catch(Exception err)
            {
                _logger.LogWarning($"Exception occured: {err}");
                return View("Index");
            }
        
        }
    }



}