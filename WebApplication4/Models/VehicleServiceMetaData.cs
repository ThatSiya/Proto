﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class VehicleServiceMetaData
    {
        [Key]
        public int VehicleServiceID { get; set; }


        [Required(ErrorMessage = "Service Date cannot be blank")]
        [Display(Name = "Service Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime VehicleService_Date { get; set; }

        [Display(Name = "Service Cost")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Service Cost must be entered in decimal form")]
        public Nullable<decimal> VehicleService_Cost { get; set; }

        [Required(ErrorMessage = "Service Mileage cannot be blank")]
        [Display(Name = "Service Mileage")]
        [RegularExpression("[0-9]+", ErrorMessage = "Service Mileage must be numeric")]
        [Range(minimum: 1, maximum: 99999999, ErrorMessage = "Service Mileage cannot be negative or zero")]
        public int VehicleService_Mileage { get; set; }
    }
}