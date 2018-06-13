using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class GenderMetaData
    {

        [Key]
        public int GenderID { get; set; }


        [Required(ErrorMessage = "Gender cannot be blank")]
        [Display(Name = "Gender")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Gender description must be alphabetic")]
        public string GenderDescr { get; set; }

    }
}