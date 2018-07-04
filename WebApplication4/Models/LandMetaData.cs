using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class LandMetaData
    {

        [Key]
        public int LandID { get; set; }

        [Required(ErrorMessage = "Land name cannot be blank")]
        [Display(Name = "Land name")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Land name must be made up of letters and numbers only")]
        public string LandName { get; set; }

    }
}