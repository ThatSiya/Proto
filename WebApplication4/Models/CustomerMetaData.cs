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
        [StringLength(maximumLength: 10, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Contact number must be numeric")]
        public string CustomerContactNum { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        public string ContactPersonalEmailAddress { get; set; }

        [Required(ErrorMessage = "Company Name cannot be blank")]
        [Display(Name = "Company Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Company Name must be alphabetic")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Company Address cannot be blank")]
        [Display(Name = "Company Address")]
        [StringLength(maximumLength: 100, ErrorMessage = "Max 50 characters reached")]
        //[RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Unit must be alphabetic")]
        public string CompanyPhysAddress { get; set; }

        [Required(ErrorMessage = "Telephone number cannot be blank")]
        [Display(Name = "Telephone number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Telephone number must be numeric")]
        public string CompanyTelNum { get; set; }
    }
}