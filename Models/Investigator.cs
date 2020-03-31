using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Investigator
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public int ActiveInvestigations { get; set; }
        public int TotalInvestigations { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
