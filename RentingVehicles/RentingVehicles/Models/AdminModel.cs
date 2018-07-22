using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentingVehicles.Models
{
    public class AdminModel
    {
        [Display(Name = "AdminId")]
        [Required(ErrorMessage = "*")]
        public int AdminID { get; set; }
        [Display(Name = "AdminName")]
        [Required(ErrorMessage = "*")]
        public string AdminName { get; set; }
        [Display(Name = "AdminPasword")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
        [Display(Name = "AdminContactNo")]
        [Required(ErrorMessage = "*")]
        public string AdminContactNo { get; set; }

    }
}
