using Nemesys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class CreateUserViewModel
    {
        public User User { get; set; }

        public String ConfirmEmail { get; set; }

        public String ConfirmPassword { get; set; }
    }
}
