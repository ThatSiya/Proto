using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class OrderMetaData
    {

        [Key]
        public int OrderNum { get; set; }

        //if above snippet does not work, try below snippet ("OrderId")
        //[Key]
        //public int OrderId { get; set; }

        [Required(ErrorMessage = "Order date cannot be blank")]
        [Display(Name = "Order Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Item Price cannot be blank")]
        [Display(Name = "Item Price")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Item Price must be entered in decimal form")]
        public decimal OrderItemPrice { get; set; }

        [Required(ErrorMessage = "Item cannot be blank")]
        [Display(Name = "Item Name")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Item Name must be made up of letters and numbers only")]
        public string OrderItem { get; set; }

    }
}