﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class OrderStatusMetaData
    {

        [Key]
        public int OrderStatusID { get; set; }


        [Required(ErrorMessage = "Status cannot be blank")]
        [Display(Name = "Status")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Status must be alphabetic")]
        public string OrderStatusDescr { get; set; }

    }
}