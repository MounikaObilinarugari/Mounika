using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentingVehicles.Models
{
    [Table("tbl_login")]
    public class LoginModel
    {

        [Display(Name = "LoginID")]
        [Required(ErrorMessage = "*")]
        
        public string LoginID { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "*")]
       
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        [Required(ErrorMessage = "*")]
        public bool RememberMe { get; set; }
    }
}