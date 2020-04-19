using Nemesys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class CreateUserErrorsViewModel
    {
        public Boolean PasswordIncorrect { get; set; }
        public Boolean EmailIncorrect { get; set; }

        public String OriginalEmail { get; set; }

        public String OriginalUsername { get; set; }
    }
}
