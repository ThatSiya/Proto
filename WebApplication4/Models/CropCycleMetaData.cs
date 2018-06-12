using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class CropCycleMetaData
    {
        [Key]
        public int CropCycleID { get; set; }
        [Required(ErrorMessage = "Start Date cannot be blank")]
        [Display(Name = "Start Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime CropCycleStartDate { get; set; }

        [Required(ErrorMessage = "End Date cannot be blank")]
        [Display(Name = "End Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime CropCycleEndDate { get; set; }

        [Required(ErrorMessage = "Crop Cycle cannot be blank")]
        [Display(Name = "Crop Cycle")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Inventory type description must be alphabetic")]
        public string CropCycleDescr { get; set; }
    }
}
