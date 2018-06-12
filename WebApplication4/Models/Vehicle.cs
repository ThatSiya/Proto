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

    [MetadataType(typeof(VehicleMetaData))]
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.VehicleServices = new HashSet<VehicleService>();
        }
    
        public int VehicleID { get; set; }
        public string VehYear { get; set; }
        public string VehModel { get; set; }
        public string VehEngineNum { get; set; }
        public string VehVinNum { get; set; }
        public string VehRegNum { get; set; }
        public string VehLicenseNum { get; set; }
        public Nullable<System.DateTime> VehExpDate { get; set; }
        public int VehCurrMileage { get; set; }
        public string VehServiceInterval { get; set; }
        public System.DateTime VehNextService { get; set; }
        public int FarmID { get; set; }
        public int VehTypeID { get; set; }
        public int VehMakeID { get; set; }
    
        public virtual Farm Farm { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleService> VehicleServices { get; set; }
    }
}