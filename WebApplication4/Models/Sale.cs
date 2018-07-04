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

    [MetadataType(typeof(SaleMetaData))]
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            this.SiloHarvestSales = new HashSet<SiloHarvestSale>();
        }
    
        public int SaleID { get; set; }
        public System.DateTime SaleDate { get; set; }
        public decimal SaleQty { get; set; }
        public decimal SaleAmnt { get; set; }
        public int CustomerID { get; set; }
        public string PurchaseAgreement { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiloHarvestSale> SiloHarvestSales { get; set; }
    }
}
