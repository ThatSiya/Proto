using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class AuditTypeMetaData
    {
        [Key]
        public int AuditTypeID { get; set; }

        [Required(ErrorMessage = "Audit Type cannot be blank")]
        [Display(Name = "Audit Type")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Audit Type must be alphabetic")]
        public string AuditTypeDescr { get; set; }
    }
}