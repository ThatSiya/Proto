using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FarmITApp.Models
{
    public partial class InventoryTypeMetaData
    {

        [Key]
        public int InvTypeID { get; set; }

        [Required(ErrorMessage ="Inventory type cannot be blank")]
        [Display(Name = "Inventory Type")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Inventory type description must be alphabetic")]
        public string InvTypeDescr { get; set; }
    }
}