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
        [StringLength(maximumLength: 15, ErrorMessage = "Max 15 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "First Name must be alphabetic")]
        public string FarmWorkerFName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be blank")]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 15, ErrorMessage = "Max 15 characters reached")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Last Name must be alphabetic")]
        public string FarmWorkerLName { get; set; }

        [Required(ErrorMessage = "Contact Number cannot be blank")]
        [Display(Name = "Contact Number")]
        [StringLength(maximumLength: 10, ErrorMessage = "Max 10 characters reached")]
        [RegularExpression("[0-9]+", ErrorMessage = "Contact number must be numeric")]
        public string FarmWorkerContactNum { get; set; }

        [Required(ErrorMessage = "Address cannot be blank")]
        [Display(Name = "Address")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        //[DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Surburb cannot be blank")]
        [Display(Name = "Surburb")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string Surburb { get; set; }

        [Required(ErrorMessage = "City cannot be blank")]
        [Display(Name = "City")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country cannot be blank")]
        [Display(Name = "Country")]
        [StringLength(maximumLength: 35, ErrorMessage = "Max 35 characters reached")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Province cannot be blank")]
        [Display(Name = "Province")]
        [StringLength(maximumLength: 36, ErrorMessage = "Max 36 characters reached")]
        public string Province { get; set; }


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

        [Required(ErrorMessage = "Farm cannot be blank")]
        [Display(Name = "Farm")]
        public int FarmID { get; set; }
    }
}