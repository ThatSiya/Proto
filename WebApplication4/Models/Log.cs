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

    [MetadataType(typeof(LogMetaData))]
    public partial class Log
    {
        public int LogID { get; set; }
        public System.DateTime LogInTimeStamp { get; set; }
        public System.DateTime LogOutTimeStamp { get; set; }
        public int UserAccessLevelID { get; set; }
    
        public virtual UserAccessLevel UserAccessLevel { get; set; }
    }
}
