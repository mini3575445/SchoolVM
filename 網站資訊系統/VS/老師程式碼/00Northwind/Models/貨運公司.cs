//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _00Northwind.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class 貨運公司
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 貨運公司()
        {
            this.訂貨主檔 = new HashSet<訂貨主檔>();
        }
    
        public int 貨運公司編號 { get; set; }
        public string 貨運公司名稱 { get; set; }
        public string 電話 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<訂貨主檔> 訂貨主檔 { get; set; }
    }
}
