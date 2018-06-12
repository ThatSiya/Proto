﻿
namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.AttendenceSheets = new HashSet<AttendenceSheet>();
            this.Audits = new HashSet<Audit>();
            this.Orders = new HashSet<Order>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserPassword { get; set; }
        public string UserContractNum { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public string UserIDNum { get; set; }
        public int UserAccessLevelID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendenceSheet> AttendenceSheets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Audit> Audits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual UserAccessLevel UserAccessLevel { get; set; }
    }
}