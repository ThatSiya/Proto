using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication4.Models
{
    public partial class TitleMetaData
    {
        [Key]
        public int TitleID { get; set; }



        [Required(ErrorMessage = "Title cannot be blank")]
        [Display(Name = "Title")]
        [StringLength(maximumLength: 4, ErrorMessage = "Max 4 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Title must be alphabetic")]
        public string TitleDescr { get; set; }
    }
}