using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication4.Models
{
    public partial class FarmWorkerMetaData
    {
        [Key]
        public int FarmWorkerNum { get; set; }

        //if above "farmworkerNum" does not work, try using below snippet instead ("FarmWorkerId")
        //[Key]
        //public int FarmWorkerId { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "First Name must be alphabetic")]
        public string FarmWorkerFName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be blank")]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max 50 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Last Name must be alphabetic")]
        public string FarmWorkerLName { get; set; }

        [Required(ErrorMessage = "Contact Number cannot be blank")]
        [Display(Name = "Contact Number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Contact number must be numeric")]
        public string FarmWorkerContactNum { get; set; }

        [Required(ErrorMessage = "Physical Address cannot be blank")]
        [Display(Name = "Physical Address")]
        [StringLength(maximumLength: 100, ErrorMessage = "Max 100 characters reached")]
        [DataType(DataType.MultilineText)]
        public string FarmWorkerPhysicalAddress { get; set; }


        [Required(ErrorMessage = "Contract Start Date cannot be blank")]
        [Display(Name = "Contract Start Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime ContractStartDate { get; set; }

        [Required(ErrorMessage = "Contract End Date cannot be blank")]
        [Display(Name = "Contract End Date")]
        //TODO: Validate future date selection
        [DataType(DataType.Date)]
        public System.DateTime ContractEndDate { get; set; }

        [Required(ErrorMessage = "ID Number cannot be blank")]
        [Display(Name = "ID Number")]
        [StringLength(maximumLength: 13, ErrorMessage = "Max 13 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "ID Number must be digits")]
        public string FarmWorkerIDNum { get; set; }
    }
}