using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class CreateReport
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Reporter Reporter { get; set; }
        public string Hazardtype { get; set; }
        
        public string Details { get; set; }
        public string Location { get; set; }
        public string ImageLocation { get; set; }

        public string HazardType { get; set; }
        
        public string status { get; set; }
        public int likes { get; set; }

    }
}
