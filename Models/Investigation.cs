using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Investigation
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public DateTime StartDate { get; set; }
        public int ReportId { get; set; }
        public int InvestigatorId { get; set; }
    }
}
