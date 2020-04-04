using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Microsoft.EntityFrameworkCore;

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
            
            var report = _context.Report.Include(report => report.Reporter).ToList();
            
            return View(report);
        }

        public IActionResult Details(int id)
        {
            var report = _context.Report.Include(report => report.Reporter).SingleOrDefault(c => c.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

    }
}