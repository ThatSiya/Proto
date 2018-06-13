﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class BiologicalDisasterMetaData
    {
        [Key]
        public int BioDisasterID { get; set; }

        [Required(ErrorMessage = "Biological Disaster cannot be blank")]
        [Display(Name = "Biological Disaster")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Biological Disaster must be alphabetic")]
        public string BioDisasterDescr { get; set; }

        [Required(ErrorMessage = "Biological Disaster Notes cannot be blank")]
        [Display(Name = "Biological Disaster Notes")]
        [StringLength(maximumLength: 255, ErrorMessage = "Max 255 characters reached")]
        [DataType(DataType.MultilineText)]
        public string BioDisasterNotes { get; set; }
    }
}