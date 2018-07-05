using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class FarmWorkerTypeMetaData
    {
        [Key]
        public int FarmWorkerTypeID { get; set; }

        [Required(ErrorMessage = "Farm Worker type cannot be blank")]
        [Display(Name = "Farm Worker Type")]
        [StringLength(maximumLength: 30, ErrorMessage = "Max 30 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Farm Worker type description must be alphabetic")]
        public string FarmWorkerTypeDescr { get; set; }

        [Display(Name = "Notes")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Farm Worker type description must be alphabetic")]
        public string FarmWorkerTypeNotes { get; set; }

        [Required(ErrorMessage = "Active Status must be indicated")]
        [Display(Name = "Active Status")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        public bool FarmWorkerTypeActiveStatus { get; set; }

    }
}