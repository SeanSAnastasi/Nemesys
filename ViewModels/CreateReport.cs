using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Nemesys.Models
{
    public class CreateReport
    {
        public int Id { get; set; }

        [StringLength(25, MinimumLength = 4, ErrorMessage = "Minimum Title Length 4")]
        [RegularExpression(@"^[a-zA-Z, ]*$", ErrorMessage = "Invalid Input - Title")]
        [Required(ErrorMessage ="Title is Required")]
        public string Title { get; set; }
        public Reporter Reporter { get; set; }
        //public string Hazardtype { get; set; }

        [RegularExpression(@"^[a-zA-Z,/n ]*$", ErrorMessage = "Invalid Input - Details")]
        [StringLength(1000, MinimumLength = 25, ErrorMessage = "Minimum Description Length 25")]
        [Required(ErrorMessage = "Please fill in the Details")]
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
