using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class ReporterModel
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public int ActiveReports { get; set; }
        public int HandledReports { get; set; }
        public int PendingReports { get; set; }
        
        public string phone { get; set; }
    }
   
}
