//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Match.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MetaActivity))]
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            this.Activity_detail = new HashSet<Activity_detail>();
        }
    
        public string activity_id { get; set; }
        public string activity_type_id { get; set; }
        public string activity_name { get; set; }
        public System.DateTime activity_datetime { get; set; }
        public string place_id { get; set; }
        public string member_id { get; set; }
        public System.DateTime activity_create_date { get; set; }
        public System.DateTime activity_join_deadline { get; set; }
        public int activity_lower { get; set; }
        public int activity_upper { get; set; }
        public int state_id { get; set; }
    
        public virtual Activity_type Activity_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity_detail> Activity_detail { get; set; }        
        public virtual Member Member { get; set; }
        public virtual Place Place { get; set; }
        public virtual State State { get; set; }
    }
}
