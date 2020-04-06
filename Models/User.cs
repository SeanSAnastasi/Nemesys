using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Username { get; set; }
    }
}
