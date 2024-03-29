﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nemesys.Areas.Identity.Data;
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

        public IActionResult Hall_Of_Fame()
        {

            List<Reporter> reporters = _context.Reporter.Include(reporters => reporters.User).OrderByDescending(c => c.HandledReports).Take(10).ToList();


            return View(reporters);
        }

        
       
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
