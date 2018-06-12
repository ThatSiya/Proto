using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class FieldStageMetaData
    {
        [Key]
        public int FieldStageID { get; set; }


        [Required(ErrorMessage = "Field Stage cannot be blank")]
        [Display(Name = "Field Stage")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Field Stage description must be alphabetic")]
        public string FieldStageDescr { get; set; }
    }
}