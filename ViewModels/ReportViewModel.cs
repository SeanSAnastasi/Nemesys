using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class ReportViewModel
    {
        public String Title { get; set; }
        public String Description { get; set; }

        public String Location { get; set; }


     
        //public string Hazardtype { get; set; }

        public string Details { get; set; }
       
     
        public String HazardType { get; set; }
  

    }
    public enum HazardType
    {
        Dangerous,
        Fair,
        Minimal
    }

    public enum Location
    {

        Qawra,
        Sliema,
        Mosta,
        Bormla,
        Valletta,
        Hamrun

    }









}

