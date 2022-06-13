using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class MetaCategories
    {
        [DisplayName("類別編號")]
        public int CategoryID { get; set; }

        [DisplayName("類別名稱")]
        [Required(ErrorMessage = "請輸入類別名稱")]
        [StringLength(15,ErrorMessage = "類別名稱最多15個字")]
        public string CategoryName { get; set; }

        [DisplayName("類別說明")]
        public string Description { get; set; }

        [DisplayName("類別圖示")]
        public byte[] Picture { get; set; }
    }


    public class MetaProducts
    {
        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "請輸入產品名稱")]
        [StringLength(40, ErrorMessage = "產品名稱最多40個字")]
        public string ProductName { get; set; }

        [DisplayName("供應商")]
        public int SupplierID { get; set; }

        [DisplayName("產品類別")]
        public int CategoryID { get; set; }

        [DisplayName("產品單位")]
        [Required(ErrorMessage = "請輸入產品單位")]
        [StringLength(20, ErrorMessage = "產品單位最多20個字")]
        public string QuantityPerUnit { get; set; }

        [DisplayName("產品單價")]
        [Required(ErrorMessage = "請輸入產品單價")]
        [Range(double.Epsilon,double.MaxValue,ErrorMessage = "產品單價必須大於0")]
        public decimal UnitPrice { get; set; }

        [DisplayName("庫存量")]
        [Required(ErrorMessage = "請輸入庫存量")]
        [Range(0,short.MaxValue, ErrorMessage = "庫存量必須大於0")]
        public short UnitsInStock { get; set; }

        [DisplayName("已採購量")]
        [Required(ErrorMessage = "請輸入已採購量")]
        [Range(0, short.MaxValue, ErrorMessage = "已採購量必須大於0")]
        public short UnitsOnOrder { get; set; }

        [DisplayName("安全存量")]
        [Required(ErrorMessage = "請輸入安全存量")]
        [Range(0, short.MaxValue, ErrorMessage = "安全存量必須大於0")]
        public short ReorderLevel { get; set; }

        [DisplayName("是否銷售")]
        [DefaultValue(false)]
        public bool Discontinued { get; set; }
    }
}