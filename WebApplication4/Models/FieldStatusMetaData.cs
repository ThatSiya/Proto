using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class FieldStatusMetaData
    {

        [Key]
        public int FieldStatID { get; set; }


        [Required(ErrorMessage = "Field Status cannot be blank")]
        [Display(Name = "Field Status")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Field Status description must be alphabetic")]
        public string FieldStatDescr { get; set; }

        [Required(ErrorMessage = "Status Pre-Condition cannot be blank")]
        [Display(Name = "Status Pre-Condition")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Status Pre-Condition must be alphabetic")]
        public string StatPreConditions { get; set; }
    }
}