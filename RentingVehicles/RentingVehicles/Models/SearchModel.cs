using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentingVehicles.Models
{
   
    public class SearchModel
    {
        [Display(Name ="City")]
        [Required(ErrorMessage ="*")]
        public string City { get; set; }

        [Display(Name ="Category")]
        [Required(ErrorMessage ="*")]
        public string Category { get; set; }
    }
}