using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class TreatmentMetaData
    {
        [Key]
        public int TreatmentID { get; set; }


        [Required(ErrorMessage = "Treatment cannot be blank")]
        [Display(Name = "Treatment")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        public string TreatmentDescr { get; set; }
    }
}