using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FarmITApp.Models
{
    public partial class AttendanceSheetMetaData
    {
        [Key]
        public int AttendenceSheetID { get; set; }

        [Required(ErrorMessage = "Clock In Time cannot be blank")]
        [Display(Name = "Clock In Time")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.TimeSpan ClockInTime { get; set; }

        [Required(ErrorMessage = "Clock Out Time cannot be blank")]
        [Display(Name = "Clock Out Time")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.TimeSpan ClockOutTime { get; set; }

    }
}