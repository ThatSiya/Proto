using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmITApp.Models
{
    public partial class PlantationMetaData
    {
        [Key]
        public int PlantationID { get; set; }

        [Display(Name = "Date Planted")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime DatePlanted { get; set; }

        [Display(Name = "Refuge Seed Amount")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = "Invalid input format")]
        public Nullable<decimal> RefugeSeedAmntUsed { get; set; }

        [Display(Name = "Refuge Area Hectares")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = "Invalid input format")]
        public Nullable<decimal> RefugeAreaHectares { get; set; }

        [Required(ErrorMessage = "Expectied Yield Qty cannot be blank")]
        [Display(Name = "Expectied Yield Qty")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = "Invalid input format")]
        public decimal ExpectedYieldQnty { get; set; }

        [Display(Name = "Date Harvested")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime DateHarvested { get; set; }

        [Required(ErrorMessage = "Plantatioin Status cannot be blank")]
        [Display(Name = "Plantation Status")]
        [StringLength(maximumLength: 20, ErrorMessage = "Max 20 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Plantation Status must be alphabetic")]
        public string PlantationStatus { get; set; }
    }
}