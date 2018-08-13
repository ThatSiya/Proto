﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmITApp.Models
{
    public partial class UserMetaData
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username cannot be blank")]
        [Display(Name = "Username")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Description must be made up of letters and numbers only")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        // Need to Test if this works
        [RegularExpression("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please Enter a Valid Email Address")]
        public string UserEmailAddress { get; set; }

        //[Required(ErrorMessage = "Password cannot be blank")]
        //[Display(Name = "Password")]
        //[StringLength(maximumLength: 30, ErrorMessage = "Max 30 characters reached")]
        ////instantiate minimum length for password ? 
        //public string UserPassword { get; set; }

        [Display(Name = "Contact Number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Contact number must be numeric")]
        public string UserContractNum { get; set; }

        [Required(ErrorMessage = "First Name cannot be blank")]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "First Name must be alphabetic")]
        public string UserFName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be blank")]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Last Name must be alphabetic")]
        public string UserLName { get; set; }

        [Required(ErrorMessage = "ID Number cannot be blank")]
        [Display(Name = "ID Number")]
        [StringLength(maximumLength: 13, ErrorMessage = "Max 13 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "ID Number must be digits")]
        public string UserIDNum { get; set; }
    }
}