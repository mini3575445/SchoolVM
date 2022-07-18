using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace HW7Project.Models
{
    //1.使用NUGET裝EntityFramework
    public class HW7ProjectContext:DbContext
    {
        //3.建立建構子，及修改WebConfig
        public HW7ProjectContext() : base("name=HW7ProjectConnection")
        { }


        //2.填資料表，若有ViewMode不用加進來
        public DbSet<Employees> Employees { get; set; } //一個資料表
        public DbSet<Members> Members { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<PayTypes> PayTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shippers> Shippers { get; set; }

        public System.Data.Entity.DbSet<HW7Project.Models.VMMember> VMMembers { get; set; }
    }
}