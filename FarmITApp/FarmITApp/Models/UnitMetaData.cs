using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FarmITApp.Models
{
    public partial class UnitMetaData //TODO: Add navigation properties
    {
        [Key]
        public int UnitID { get; set; }

        [Required(ErrorMessage = "Unit cannot be blank")]
        [Display(Name = "Unit")]
        [StringLength(maximumLength: 5, ErrorMessage = "Max 5 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Unit must be alphabetic")]
        public string UnitDescr { get; set; }

    }
}