using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Report
    {
        public int Id { get; set; }
        [Required]
        public Reporter Reporter { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public String HazardType { get; set; }
        [Required]
        public String Status { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public byte[] ImageLocation { get; set; }
        public int Likes { get; set; }

    }
}

