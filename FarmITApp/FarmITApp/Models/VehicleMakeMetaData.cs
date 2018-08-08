using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FarmITApp.Models
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
