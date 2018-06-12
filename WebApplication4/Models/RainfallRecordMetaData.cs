using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class RainfallRecordMetaData
    {

        [Key]
        public int RainFallRecID { get; set; }


        [Required(ErrorMessage = "Record date cannot be blank")]
        [Display(Name = "Record Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime RecordDate { get; set; }

        [Required(ErrorMessage = "Record measurement cannot be blank")]
        [Display(Name = "Measurement")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Measurement must be entered in decimal form")]
        public decimal RecordMeasurement { get; set; }
    }
}