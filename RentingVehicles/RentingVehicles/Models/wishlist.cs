using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentingVehicles.Models
{
    [Table("tbl_wishlist")]
    public class wishlistmodel
    {
        [Display(Name = "wishlistid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wishlistid { get; set; }

        [Column("UserID")]
        [Display(Name = "UserID")]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public NewUserModel pUserID { get; set; }

        [Column("VehicleID")]
        [Display(Name = "VehicleID")]
        public string VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public AddVehicleModel pVehicleID { get; set; }
       
    }
}