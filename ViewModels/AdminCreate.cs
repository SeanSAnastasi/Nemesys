using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class AdminCreate
    {
        [Display(Name = "User name")]
        public String UserName { get; set; }

        [Display(Name = "User type")]
        public String UserType { get; set; }

    }
    public enum UserType
    {
        Reporter,
        Investigator,
        Admin
    }
}
