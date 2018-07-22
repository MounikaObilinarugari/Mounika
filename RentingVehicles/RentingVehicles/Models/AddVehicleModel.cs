using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentingVehicles.Models
{
    [Table("tbl_AddVehicle")]
    public class AddVehicleModel
    {


        [Display(Name = "VehicleID")]
        [Required(ErrorMessage = "*")]
        [Key]
        public string VehicleID { get; set; }
        [Display(Name = "VehicleName")]
        [Required(ErrorMessage = "*")]
        public string VehicleName { get; set; }
        [Display(Name = "VehicaleType")]
        [Required(ErrorMessage = "*")]
        public string VehicleType { get; set; }
        [Display(Name = "VehiclePrice")]
        [Required(ErrorMessage = "*")]
        public int VehiclePrice { get; set; }
        [Display(Name = "VehicaleCategory")]
        [Required(ErrorMessage = "*")]
        public string VehicleCategory { get; set; }
        [Display(Name = "VehicleAddData")]
        [Required(ErrorMessage = "*")]
        public DateTime VehicleAddDate { get; set; }
        [Display(Name = "VehicleAddBy")]
        [Required(ErrorMessage = "*")]

        public string VehicleAddBy { get; set; }
        [Display(Name = "VehicleImageAddress")]
 //       [Required(ErrorMessage = "*")]
        public string VehicleImageAddress { get; set; }
        [Display(Name = "VehicleMilage")]
        [Required(ErrorMessage = "*")]
        
        public int VehicleMilage { get; set; }

       [Column("UserID")] 
      [Display(Name ="UserID")]
      //[Required(ErrorMessage ="*")]
       
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public NewUserModel Puserid { get; set; }

        [Display(Name ="City")]
        [Required(ErrorMessage ="*")]
        public string City { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "*")]
        public string Location { get; set; }

    }
}



