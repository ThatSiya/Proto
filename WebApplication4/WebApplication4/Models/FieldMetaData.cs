using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class FieldMetaData
    {
        [Key]
        public int FieldID { get; set; }

        [Required(ErrorMessage = "Field Name cannot be blank")]
        [Display(Name = "Field Name")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Field Name must be made up of letters and numbers only")]
        public string FieldName { get; set; }

        [Required(ErrorMessage ="Hectares cannot be blank")]
        [Display(Name = "Hectares")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = "Invalid input format")]
        public decimal FieldHectares { get; set; }

    }
}