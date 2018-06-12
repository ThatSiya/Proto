﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class SupplierMetaData
    {

        [Key]
        public int SupplierID { get; set; }


        [Required(ErrorMessage = "Name cannot be blank")]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Name must be alphabetic")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Physical Address cannot be blank")]
        [Display(Name = "Physical Address")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 50 characters reached")]
        [DataType(DataType.MultilineText)]
        public string SupplierPhysAddress { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        public string SupplierEmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number cannot be blank")]
        [Display(Name = "Phone number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Phone number must be numeric")]
        public string SupplierPhoneNum { get; set; }

        [Required(ErrorMessage = "Cellphone number cannot be blank")]
        [Display(Name = "Cellphone number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Cellphone number must be numeric")]
        public string SupplierCellNum { get; set; }
    }
}