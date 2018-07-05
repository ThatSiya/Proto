using System;
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
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = "Invalid input format")]
        public Nullable<decimal> VehicleService_Cost { get; set; }

        [Required(ErrorMessage = "Service Mileage cannot be blank")]
        [Display(Name = "Service Mileage")]
        [RegularExpression("[0-9]+", ErrorMessage = "Service Mileage must be numeric")]
        [Range(minimum: 1, maximum: 99999999, ErrorMessage = "Service Mileage cannot be negative or zero")]
        public int VehicleService_Mileage { get; set; }

        [Required(ErrorMessage = "Service Unit cannot be blank")]
        [Display(Name = "Service Record Unit")]
        [StringLength(maximumLength: 5, ErrorMessage = "Max 5 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Description must be alphabetic")]
        public string VehicleServiceRecordUnit { get; set; }
    }
}