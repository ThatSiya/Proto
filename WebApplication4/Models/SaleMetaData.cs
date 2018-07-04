using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class SaleMetaData
    {
        [Key]
        public int SaleID { get; set; }


        [Required(ErrorMessage = "Sale date cannot be blank")]
        [Display(Name = "Sale Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime SaleDate { get; set; }

        [Required(ErrorMessage = "Quantity cannot be blank")]
        [Display(Name = "Quantity")]
        [RegularExpression("[0-9]+", ErrorMessage = "Quantity must be numeric")]
        [Range(minimum: 1, maximum: 999999, ErrorMessage = "Quantity cannot be negative or zero")]
        public decimal SaleQty { get; set; }

        [Required(ErrorMessage = "Sale Amount cannot be blank")]
        [Display(Name = "Sale Amount")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Total Amount must be entered in decimal form")]
        public decimal SaleAmnt { get; set; }

        [Required(ErrorMessage = "Purchase Agreement cannot be blank. Provide N/A if not applicable")]
        [Display(Name = "Purchase Agreement")]
        [StringLength(maximumLength: 255, ErrorMessage = "Max 255 characters reached")]
        [DataType(DataType.MultilineText)]
        public string PurchaseAgreement { get; set; }
    }
}