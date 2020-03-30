using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nemesys.Models
{
    public class ReporterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}