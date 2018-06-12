using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class InventoryTreatmentMetaData
    {
        [Key, Column(Order =0)]
        public int TreatmentID { get; set; }
        [Key, Column(Order =1)]
        public int InventoryID { get; set; }
        [Required(ErrorMessage = "Quantity cannot be blank")]
        [Display(Name = "Quantity")]
        [RegularExpression("[0-9]+", ErrorMessage = "Quantity must be numeric")]
        [Range(minimum: 1, maximum: 999999, ErrorMessage = "Quantity cannot be negative or zero")]
        public int TreatmentQnty { get; set; }

        [Required(ErrorMessage = "Unit cannot be blank")]
        [Display(Name = "Unit")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Unit must be alphabetic")]
        public string TreatmentUnit { get; set; }

    }
}