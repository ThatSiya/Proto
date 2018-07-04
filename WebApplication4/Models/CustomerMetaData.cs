using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class CustomerMetaData
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "First Name must be alphabetic")]
        public string CustomerFName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be blank")]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Last Name must be alphabetic")]
        public string CustomerLName { get; set; }

        [Required(ErrorMessage = "Contact Number cannot be blank")]
        [Display(Name = "Contact Number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Contact number must be numeric")]
        public string CustomerContactNum { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string ContactPersonalEmailAddress { get; set; }

        [Required(ErrorMessage = "Company Name cannot be blank")]
        [Display(Name = "Company Name")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Company Name must be alphabetic")]
        public string CompanyName { get; set; }

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
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Telephone number cannot be blank")]
        [Display(Name = "Telephone number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Telephone number must be numeric")]
        public string CompanyTelNum { get; set; }
    }
}