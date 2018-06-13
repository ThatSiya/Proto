using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class FarmMetaData
    {
        [Key]
        public int FarmID { get; set; }


        [Required(ErrorMessage = "Farm Name cannot be blank")]
        [Display(Name = "Farm Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Farm Name must be alphabetic")]
        //Regex should only include alphabetic numbers ? 
        public string FarmName { get; set; }
    }
}