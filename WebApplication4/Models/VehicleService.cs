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

    [MetadataType(typeof(VehicleServiceMetaData))]
    public partial class VehicleService
    {
        public int VehicleServiceID { get; set; }
        public System.DateTime VehicleService_Date { get; set; }
        public Nullable<decimal> VehicleService_Cost { get; set; }
        public int VehicleService_Mileage { get; set; }
        public int VehicleID { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
    }
}