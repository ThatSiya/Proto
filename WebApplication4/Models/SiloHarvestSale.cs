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

    [MetadataType(typeof(SiloHarvestSaleMetaData))]
    public partial class SiloHarvestSale
    {
        public int SiloHarvestID { get; set; }
        public int SaleID { get; set; }
        public decimal SiloHarvestSaleTotalAmnt { get; set; }
        public decimal SiloHarvestSaleTotalQty { get; set; }
    
        public virtual Sale Sale { get; set; }
        public virtual SiloHarvest SiloHarvest { get; set; }
    }
}
