using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Like
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Reporter Reporter { get; set; }

        [Required]
        public Report Report { get; set; }
      

    }
}
