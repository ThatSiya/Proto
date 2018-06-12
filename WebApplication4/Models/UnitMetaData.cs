using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public partial class UnitMetaData //TODO: Add navigation properties
    {
        [Key]
        public int UnitID { get; set; }


        [Display(Name = "Unit")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Unit must be alphabetic")]
        public string UnitDescr { get; set; }
    }
}