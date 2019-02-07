using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleSetup3.Models
{
    public class FleetAssetBig
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FleetAssetBig()
        {

            this.FleetAssets = new HashSet<FleetAsset>();
            this.AdditionalFields = new HashSet<AdditionalField>();
            this.Capacities = new HashSet<Capacity>();
            this.Compliences = new HashSet<Complience>();
        }
        #region Fields
    //  FleetAsset
        [Required, StringLength(8)]
        public string FleetNo { get; set; }
        [Required, StringLength(12)]
        public string RegistrationNo { get; set; }
        [Required, StringLength(20)]
        public string Depot { get; set; }
        [Required, StringLength(4)]
        public string Year { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int FleetAssetMakeID { get; set; }
        public int FleetAssetModelID { get; set; }
        public int FleetAssetTypeID { get; set; }
        public int FleetAssetSubTypeID { get; set; }
        public int FuelTypeID { get; set; }
    //---------------------------------------------------

    //  Capacities
        [Range(0,99)]
        public int? Pallets { get; set; }
        [Range(0,99)]
        public int? Spaces { get; set; }
        [Range(0,9999999.99)]
        public decimal? CubicSpace { get; set; }
        [Range(0,99999.99)]
        public decimal? InternalHeight { get; set; }
        [Range(0, 99999.99)]
        public decimal? InternalWidht { get; set; }
        [Range(0, 99999.99)]
        public decimal? InternalLenght { get; set; }
        [Range(0, 9999999.999)]
        public decimal? Tare { get; set; }
        [Range(0, 9999999.999)]
        public decimal? GVM { get; set; }
        [Range(0, 9999999.999)]
        public decimal? GCM { get; set; }
        public bool IsMainCapacity { get; set; }
        [Range(0, 9999999.999)]
        public decimal? AxelWeight1 { get; set; }
        [Range(0, 9999999.999)]
        public decimal? AxelWeight2 { get; set; }
        [Range(0, 9999999.999)]
        public decimal? AxelWeight3 { get; set; }
    //---------------------------------------------------
    //  Complineces
        public int ComplienceTypeID { get; set; }
        public int ComplienceSubTypeID { get; set; }
        public string LicenceClass { get; set; }
        public string LicenseNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateObtained { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ValidFromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }
        public string AlertOperation { get; set; }
        //---------------------------------------------------
        //  AdditionalFields
        [StringLength(50)]
        public string AdditionalFieldName { get; set; }
        [StringLength(50)]
        public string AdditionalFieldValue { get; set; }
        //---------------------------------------------------
        //Attachments
        public string AttachmentName { get; set; }
        public string AttachmentExtension { get; set; }
        public string AttachmentSize { get; set; }
        public string AttachmentPath { get; set; }
        public byte[] Image { get; set; }
        public bool IsDefaultImage { get; set; }

        #endregion

        #region Virtual
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
        public virtual FleetAsset FleetAsset { get; set; }
        public virtual ComplienceSubType ComplienceSubType { get; set; }
        public virtual ComplienceType ComplienceType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FleetAsset> FleetAssets { get; set; }
        #endregion
    }
}