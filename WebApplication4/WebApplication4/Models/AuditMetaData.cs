﻿using System;
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
        [Required(ErrorMessage = "Reference table cannot be blank")]
        [Display(Name = "Reference table")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Reference table must be alphabetic")]
        public string AuditRefTable { get; set; }

        public System.DateTime TrxDate { get; set; }
        public System.TimeSpan TrxTime { get; set; }

        [Required(ErrorMessage = "TrxNewRecord cannot be blank")]
        [Display(Name = "Trx New Record")]
        [StringLength(maximumLength: 255, ErrorMessage = "Max 255 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "TrxNewRecord must be alphabetic")]
        public string TrxNewRecord { get; set; }

        [Required(ErrorMessage = "TrxOldRecord cannot be blank")]
        [Display(Name = "Trx Old Record")]
        [StringLength(maximumLength: 255, ErrorMessage = "Max 255 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "TrxOldRecord must be alphabetic")]
        public string TrxOldRecord { get; set; }

        [Required(ErrorMessage = "AuditRefAtrribute cannot be blank")]
        [Display(Name = "AuditRefAtrribute")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "AuditRefAtrribute must be alphabetic")]
        public string AuditRefAtrribute { get; set; }
    }
}