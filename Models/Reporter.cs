using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Reporter
    {
        public int Id { get; set; }       
        public User User { get; set; }
        public int ActiveReports { get; set; }
        public int HandledReports { get; set; }
        public int PendingReports { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
