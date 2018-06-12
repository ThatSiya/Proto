using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class CropTypeMetaData
    {
        [Key]
        public int CropTypeID { get; set; }

        [Required(ErrorMessage = "Crop type cannot be blank")]
        [Display(Name = "Crop Type")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Crop type description must be alphabetic")]
        public string CropTypeDescr { get; set; }

        [Required(ErrorMessage = "Crop type cannot be blank")]
        [Display(Name = "Crop Type")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        public string MaturityDays { get; set; }

    }
}