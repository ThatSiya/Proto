//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(InventoryTreatmentMetaData))]

    public partial class InventoryTreatment
    {
        public int TreatmentID { get; set; }
        public int InventoryID { get; set; }
        public int TreatmentQnty { get; set; }
        public string TreatmentUnit { get; set; }
    
        public virtual Inventory Inventory { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
