//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Materail.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PO()
        {
            this.POR = new HashSet<POR>();
        }
    
        public string poId { get; set; }
        public string memId { get; set; }
        public string supId { get; set; }
        public string goodId { get; set; }
        public double poNum { get; set; }
        public string Unit { get; set; }
        public decimal poUnitPrice { get; set; }
        public System.DateTime poCreateTime { get; set; }
        public byte poStatus { get; set; }
        public string poNotes { get; set; }
    
        public virtual Members Members { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POR> POR { get; set; }
    }
}
