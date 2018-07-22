using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentingVehicles.Models
{
    [Table("tbl_NewUser")]
    public class NewUserModel
    {

        [Display(Name = "UserID")]
        [Required(ErrorMessage = "*")]
      [Key]
      [EmailAddress]
        public string UserID { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string Gender { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string City { get; set; }

        [NotMapped]
        [Display(Name ="Password")]
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
     
        public string Password { get; set; }
        [Display(Name ="MobileNumber")]
        [Required(ErrorMessage ="*")]
        [RegularExpression("^[7-9][0-9]{9}$",ErrorMessage ="InvalidFormat")]
        public string MobileNumber { get; set; }


      //  public List<AddVehicleModel> Vehicles { get; set; }
    }
}