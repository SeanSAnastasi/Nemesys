using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Investigation
    {
        public int Id { get; set; }
        [Required]
        public Reporter Reporter { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public Report Report { get; set; }
        [Required]
        public Investigator Investigator { get; set; }

    }
}
