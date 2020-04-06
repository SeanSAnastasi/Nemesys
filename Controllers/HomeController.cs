using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nemesys.Models;
using Nemesys.ViewModels;

namespace Nemesys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NemesysDBContext _context;

        

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public HomeController(ILogger<HomeController> logger, NemesysDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            var reporters = _context.Reporter;


            return View(reporters);
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            var viewModel = new CreateUserErrorsViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(User user,String confirmEmail,String confirmPassword)
        {
            
            if(user.Email != confirmEmail || user.Password != confirmPassword)
            {


                var viewModel = new CreateUserErrorsViewModel
                {
                    OriginalEmail = user.Email,
                    OriginalUsername = user.Username
                };
                if (user.Email != confirmEmail)
                    viewModel.EmailIncorrect = true;
                if (user.Password != confirmPassword)
                    viewModel.PasswordIncorrect = true;
                return View("Signup",viewModel);
            }

            _context.User.Add(user);
            
            Reporter reporter = new Reporter
            {
                User = user,
                ActiveReports = 0,
                PendingReports = 0,
                HandledReports = 0
            };
            _context.Reporter.Add(reporter);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
