//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleSetup3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FleetAsset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FleetAsset()
        {
            this.AdditionalFields = new HashSet<AdditionalField>();
            this.Attachments = new HashSet<Attachment>();
            this.Capacities = new HashSet<Capacity>();
            this.Compliences = new HashSet<Complience>();
        }
    
        public string FleetNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Depot { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public int FleetAssetMakeID { get; set; }
        public int FleetAssetModelID { get; set; }
        public int TypeID { get; set; }
        public int SubTypeID { get; set; }
        public int FuelTypeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdditionalField> AdditionalFields { get; set; }
        public virtual AssetSubType AssetSubType { get; set; }
        public virtual AssetType AssetType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachment> Attachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Capacity> Capacities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complience> Compliences { get; set; }
        public virtual FleetAssetMake FleetAssetMake { get; set; }
        public virtual FleetAssetModel FleetAssetModel { get; set; }
        public virtual FuelType FuelType { get; set; }
    }
}
