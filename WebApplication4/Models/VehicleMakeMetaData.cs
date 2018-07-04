using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class VehicleMakeMetaData
    {
        [Key]
        public int VehMakeID { get; set; }


        [Required(ErrorMessage = "Vehicle Make cannot be blank")]
        [Display(Name = "Vehicle Make")]
        [StringLength(maximumLength: 30, ErrorMessage = "Max 30 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Vehicle Make description must be alphabetic")]
        public string VehMakeDescr { get; set; }

    }
}