﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class FieldTreatmentMetaData
    {
        [Key, Column(Order = 0)]
        public int FieldID { get; set; }
        [Key, Column(Order = 1)]
        public int TreatmentID { get; set; }
        [Required(ErrorMessage = "Treatment date cannot be blank")]
        [Display(Name = "Treatment Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime TreatmentDate { get; set; }
    }
}