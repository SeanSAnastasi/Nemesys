
using Nemesys.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    
    public class Admin
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
