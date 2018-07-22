using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentingVehicles.Models
{
    public class VehicleRentModel
    {
        [Display(Name = "VehicleID")]
        [Required(ErrorMessage = "*")]
        public string VehicleID { get; set; }
        [Display(Name = "UserID")]
        [Required(ErrorMessage = "*")]
        public int UserID { get; set; }
        [Display(Name = "DateOfRented")]
        [Required(ErrorMessage = "*")]
        public DateTime DateOfRented { get; set; }
        [Display(Name = "DateOfReturned")]
        [Required(ErrorMessage = "*")]
        public DateTime DateOfReturn { get; set; }
        [Display(Name = "VehicleMilage")]
        [Required(ErrorMessage = "*")]
        public int VehicleMilage { get; set; }
        [Display(Name = "VehiclePrice")]
        [Required(ErrorMessage = "*")]
        public int VehiclePrice { get; set; }

    }
}