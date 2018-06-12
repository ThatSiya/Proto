using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class PlantationMetaData
    {
        [Key]
        public int PlantationID { get; set; }



        [Display(Name = "Date Planted")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime DatePlanted { get; set; }

        [Required(ErrorMessage = "Refuge Seed Amount cannot be blank")]
        [Display(Name = "Refuge Seed Amount")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Refuge Seed Amount must be entered in decimal form")]
        public Nullable<decimal> RefugeSeedAmntUsed { get; set; }

        [Required(ErrorMessage = "Unit cannot be blank")]
        [Display(Name = "Unit")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Unit must be alphabetic")]
        public string RefugeSeedUnit { get; set; }

        [Required(ErrorMessage = "Refuge Area Hectares cannot be blank")]
        [Display(Name = "Refuge Area Hectares")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Refuge Area Hectares must be entered in decimal form")]
        public Nullable<decimal> RefugeAreaHectares { get; set; }

        [Required(ErrorMessage = "Expectied Yield Qty cannot be blank")]
        [Display(Name = "Expectied Yield Qty")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Expectied Yield Qty must be entered in decimal form")]
        public decimal ExpectedYieldQnty { get; set; }

        [Required(ErrorMessage = "Yield Unit cannot be blank")]
        [Display(Name = "Yield Unit")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Yield Unit must be alphabetic")]
        public string ExpectedYieldUnit { get; set; }

        [Display(Name = "Date Harvested")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime DateHarvested { get; set; }

        [Display(Name = "Status")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Status must be alphabetic")]
        public string PlantationStatus { get; set; }
    }
}