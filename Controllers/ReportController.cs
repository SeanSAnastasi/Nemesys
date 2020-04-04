using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;

namespace Nemesys.Controllers
{
    public class ReportController : Controller
    {
        private NemesysDBContext _context;
       

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ReportController(NemesysDBContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            ViewBag.Title = "Report";
            var report = _context.Report.ToList();
            
            return View(report);
        }
    }
}