using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Nemesys.Models
{
    public class CreateReport
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Reporter Reporter { get; set; }
        //public string Hazardtype { get; set; }
        
        public string Details { get; set; }
        public string Location { get; set; }
        public Microsoft.AspNetCore.Http.IFormFile ImageLocation { get; set; }

    
        public String HazardType { get; set; }
        public string status { get; set; }
        public int likes { get; set; }

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
        Sliema ,
            Mosta ,
                Bormla ,
                    Valletta,
                        Hamrun 

    }


}
