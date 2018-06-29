using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class VehicleTypeMetaData
    {
        [Key]
        public int VehTypeID { get; set; }


        [Required(ErrorMessage = "Vehicle type cannot be blank")]
        [Display(Name = "Vehicle Type")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Vehicle type description must be alphabetic")]
        public string VehTypeDescr { get; set; }

        [Required(ErrorMessage = "Vehicle type image must be selected")]
        [Display(Name = "Vehicle Type Image")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        public string VehTypeImg { get; set; }

    }
}