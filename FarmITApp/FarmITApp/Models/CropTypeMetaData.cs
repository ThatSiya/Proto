using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmITApp.Models
{
    public partial class CropTypeMetaData
    {
        [Key]
        public int CropTypeID { get; set; }

        [Required(ErrorMessage = "Crop Type cannot be blank")]
        [Display(Name = "Crop Type")]
        [StringLength(maximumLength: 20, ErrorMessage = "Max 20 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Crop Type description must be alphabetic")]
        public string CropTypeDescr { get; set; }

        [Required(ErrorMessage = "Maturity Fays cannot be blank")]
        [Display(Name = "Maturity Days")]
        [RegularExpression("[0-9]+", ErrorMessage = "Maturity Days must be numeric")]
        [Range(minimum: 1, maximum: 999999, ErrorMessage = "Days cannot be negative or zero")]
        public string MaturityDays { get; set; }

    }
}