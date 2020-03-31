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
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Username { get; set; }
        public int ActiveReports { get; set; }
        public int HandledReports { get; set; }
        public int PendingReports { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
