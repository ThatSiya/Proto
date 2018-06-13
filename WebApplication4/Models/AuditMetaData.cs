using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public partial class AuditMetaData
    {
        [Key]
        public int AuditID { get; set; }
        public string AuditRefTable { get; set; }
        public System.DateTime TrxDate { get; set; }
        public System.TimeSpan TrxTime { get; set; }

        [Required(ErrorMessage = "TrxNewRecord cannot be blank")]
        [Display(Name = "Trx New Record")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "TrxNewRecord must be alphabetic")]
        public string TrxNewRecord { get; set; }

        [Required(ErrorMessage = "TrxOldRecord cannot be blank")]
        [Display(Name = "Trx Old Record")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "TrxOldRecord must be alphabetic")]
        public string TrxOldRecord { get; set; }

        [Required(ErrorMessage = "AuditRefAtrribute cannot be blank")]
        [Display(Name = "AuditRefAtrribute")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "AuditRefAtrribute must be alphabetic")]
        public string AuditRefAtrribute { get; set; }
    }
}