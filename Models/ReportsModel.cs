using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class ReportsModel
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }

        public int ReportId { get; set; }
        public int date { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public string Description { get; set; }
        public string imageLocation { get; set; }
        public int Likes { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

    }
}

