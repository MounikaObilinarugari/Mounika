using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentingVehicles.Models
{
   [Table("tbl_messages")]
    public class MessagesModel
    {
        [Display(Name = "MessageId")]
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }

        [Display(Name = "MessageContent")]
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string MessageContent { get; set; }
      
          
        [Column("VehicleID")]
        [Display(Name = "VehicleID")]
       // [Required(ErrorMessage = "*")]
        public string VehicleID { get; set; }


        [ForeignKey("VehicleID")]
        public AddVehicleModel pVehicleID { get; set; }

        [Column("UserID")]
        [Display(Name ="UserID")]
       // [Required(ErrorMessage ="*"]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public NewUserModel pUserID { get; set; }
      
    }
}