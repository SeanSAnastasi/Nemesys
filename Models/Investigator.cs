using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Investigator
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int ActiveInvestigations { get; set; }
        public int TotalInvestigations { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
