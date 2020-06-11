using Nemesys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class ReportIndexViewModel
    {
        public List<Report> Report { get; set; }

        public String SearchS { get; set; }
    }
}
