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
    
    public partial class Friend
    {
        public string friend_number { get; set; }
        public string friend_member1 { get; set; }
        public string friend_member2 { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Member Member1 { get; set; }
    }
}
