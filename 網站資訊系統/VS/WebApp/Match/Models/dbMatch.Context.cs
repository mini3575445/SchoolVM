﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MatchEntities : DbContext
    {
        public MatchEntities()
            : base("name=MatchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Activity_detail> Activity_detail { get; set; }
        public virtual DbSet<Activity_Type> Activity_Type { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Place_type> Place_type { get; set; }
        public virtual DbSet<Right> Right { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
