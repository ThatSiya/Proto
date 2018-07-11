using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class UserAccessLevelMetaData
    {
        [Key]
        public int UserAccessLevelID { get; set; }


        [Display(Name = "Access Level")]
        [StringLength(maximumLength: 5, ErrorMessage = "Max 5 characters reached")]
        public string UserAccessLevelDescr { get; set; }

        [Display(Name = "Notes")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        public string Notes { get; set; }
    }
}