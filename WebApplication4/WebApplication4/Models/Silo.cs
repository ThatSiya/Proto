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

    [MetadataType(typeof(SiloMetaData))]
    public partial class Silo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Silo()
        {
            this.SiloHarvests = new HashSet<SiloHarvest>();
        }
    
        public int SiloID { get; set; }
        public string SiloDescr { get; set; }
        public Nullable<double> SiloCapacity { get; set; }
        public Nullable<double> SiloRentalFeePA { get; set; }
        public string SiloStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiloHarvest> SiloHarvests { get; set; }
    }
}
