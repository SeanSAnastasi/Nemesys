using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Report
    {
        public int Id { get; set; }
        public Reporter Reporter { get; set; }

        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Status { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public byte[] ImageLocation { get; set; }
        public int Likes { get; set; }

    }
}

