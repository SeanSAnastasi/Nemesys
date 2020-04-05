﻿using System;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Title","Date","HazardType","Status","Location","Description","ImageLocation","Likes")] CreateReport newReport)
        {
            /*  if (ModelState.IsValid)
              {
                  string file = "";
                  if(newReport.)
              }*/
            Reporter reporter = new Reporter();
            reporter.Id = 1;
            Report report = new Report()
            {

                Title = newReport.Title,
                Date = DateTime.UtcNow,
                //ImageLocation = newReport.ImageLocation,
                Status = newReport.status,
                Location = newReport.Location,
                HazardType = newReport.HazardType,
                Reporter = reporter,
                Likes = 0

            };
            _context.Report.Add(report);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}