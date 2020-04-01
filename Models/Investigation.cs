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
        public int ReporterId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public int ReportId { get; set; }
        [Required]
        public int InvestigatorId { get; set; }
    }
}
