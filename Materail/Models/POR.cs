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
    
    public partial class POR
    {
        public string poRId { get; set; }
        public string poId { get; set; }
        public string memId { get; set; }
        public string supId { get; set; }
        public string goodId { get; set; }
        public double poRNum { get; set; }
        public string Unit { get; set; }
        public decimal poRUnitPrice { get; set; }
        public System.DateTime poRCreateTime { get; set; }
        public byte poRStatus { get; set; }
        public string poRNotes { get; set; }
    
        public virtual Members Members { get; set; }
        public virtual PO PO { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
