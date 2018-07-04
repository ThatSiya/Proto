using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public partial class InventoryMetaData
    {

        [Key]
        public int InventoryID { get; set; }


        [Required(ErrorMessage = "Description cannot be blank")]
        [Display(Name = "Description")]
        [StringLength(maximumLength:35, ErrorMessage ="Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage ="Description must be made up of letters and numbers only")]
        public string InvDescr { get; set; }

        [Required(ErrorMessage = "Quantity cannot be blank")]
        [Display(Name = "Quantity")]
        [RegularExpression("[0-9]+", ErrorMessage = "Quantity must be numeric")]
        [Range(minimum:1,maximum:999999, ErrorMessage ="Quantity cannot be negative or zero")]
        public int InvQty { get; set; }

        [Required(ErrorMessage = "Purchase date cannot be blank")]
        [Display(Name = "Date Purchased")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime InvDatePurchased { get; set; }

        [Required(ErrorMessage = "Inventory Code cannot be blank")]
        [Display(Name = "Inventory Code")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Inventory Code must be made up of letters and numbers only")]
        public string InvCode { get; set; }

        [Required(ErrorMessage = "Unit cannot be blank")]
        [Display(Name = "Unit")]
        [StringLength(maximumLength: 5, ErrorMessage = "Max 5 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Unit must be alphabetic")]
        public string InvSIUnit { get; set; }

        [Display(Name = "Inventory Type")]
        public int InvTypeID { get; set; }
    }
}