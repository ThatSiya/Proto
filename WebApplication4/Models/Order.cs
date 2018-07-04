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

    [MetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }
    
        public int OrderNum { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal OrderItemPrice { get; set; }
        public int SupplierID { get; set; }
        public int UserID { get; set; }
        public int FarmID { get; set; }
        public int OrderStatusID { get; set; }
        public string OrderItem { get; set; }
    
        public virtual Farm Farm { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
