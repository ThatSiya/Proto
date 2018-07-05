using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;

namespace WebApplication4.Models
{
    public partial class SupplierMetaData
    {

        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Supplier Name cannot be blank")]
        [Display(Name = "Supplier Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Name must be alphabetic")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Address cannot be blank")]
        [Display(Name = "Address")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Surburb cannot be blank")]
        [Display(Name = "Surburb")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string Surburb { get; set; }

        [Required(ErrorMessage = "City cannot be blank")]
        [Display(Name = "City")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country cannot be blank")]
        [Display(Name = "Country")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Province cannot be blank")]
        [Display(Name = "Province")]
        [StringLength(maximumLength: 36, ErrorMessage = "Max 36 characters reached")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string SupplierEmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number cannot be blank")]
        [Display(Name = "Phone number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Phone number must be numeric")]
        public string SupplierPhoneNum { get; set; }

        [Required(ErrorMessage = "Cellphone number cannot be blank")]
        [Display(Name = "Cellphone number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Cellphone number must be numeric")]
        public string SupplierCellNum { get; set; }
    }
}