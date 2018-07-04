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
        [RegularExpression("[0-9]+", ErrorMessage = "Measurement must be numeric")]
        [Range(minimum: 0, maximum: 999999, ErrorMessage = "Measurement cannot be negative")]
        public int RecordMeasurement { get; set; }
    }
}