//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HAMACO
{
    using System;
    using System.Collections.Generic;
    
    public partial class InventoryItemCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryItemCategory()
        {
            this.InventoryItems = new HashSet<InventoryItem>();
        }
    
        public System.Guid InventoryCategoryID { get; set; }
        public string CompanyCode { get; set; }
        public Nullable<System.Guid> ParentID { get; set; }
        public string MISACodeID { get; set; }
        public Nullable<bool> IsParent { get; set; }
        public Nullable<int> Grade { get; set; }
        public string InventoryCategoryCode { get; set; }
        public string InventoryCategoryName { get; set; }
        public Nullable<bool> IsTool { get; set; }
        public Nullable<bool> IsSystem { get; set; }
        public bool Inactive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}