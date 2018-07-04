using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public partial class SiloHarvestMetaData
    {
        [Key]
        public int SiloHarvestID { get; set; }


        [Display(Name = "Harvest Storage Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> SiloHarvestStoreStartDate { get; set; }

        [Display(Name = "Harvest Storage Expiry Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> SiloHarvestStoreEndDate { get; set; }

        [Required(ErrorMessage = "Harvest Tonnes Stored cannot be blank")]
        [Display(Name = "Harvest Tonnes Stored")]
        [RegularExpression(@"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", ErrorMessage = "Harvest Tonnes Stored must be entered in decimal form")]
        public decimal SiloHarvestTonnesStored { get; set; }
    }
}