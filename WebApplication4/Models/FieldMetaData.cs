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
        [StringLength(maximumLength: 20, ErrorMessage = "Max 20 characters reached")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Field Name must be made up of letters and numbers only")]
        public string FieldName { get; set; }

        [Required(ErrorMessage ="Hectares cannot be blank")]
        [Display(Name = "Hectares")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Hectares must be entered in decimal form")]
        public decimal FieldHectares { get; set; }

    }
}