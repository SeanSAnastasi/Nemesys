using Nemesys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class AdminAssign
    {
        public Report report { get; set; }

        public List<Investigator> Investigators { get; set; }
    }
}
