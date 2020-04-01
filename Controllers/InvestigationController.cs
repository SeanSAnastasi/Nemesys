using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Microsoft.EntityFrameworkCore;

namespace Nemesys.Controllers
{
    public class InvestigationController : Controller
    {

        private NemesysDBContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public InvestigationController(NemesysDBContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {

            var investigation = _context.Investigation.Include(c=>c.Report);
            Console.WriteLine(investigation.ToString());
            return View(investigation);
        }
    }
}