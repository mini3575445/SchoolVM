
namespace Northwind.Models
{
    using System;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    //將此partical class與entity類別產生關聯
    
    public class MetaCategories
    {
        //主鍵
        [DisplayName("類別編號")]
        public int CategoryID { get; set; }

        [DisplayName("類別名稱")]
        [Required(ErrorMessage ="必填欄位")]
        [StringLength(15,ErrorMessage ="最多15個字")]
        public string CategoryName { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }

        [DisplayName("圖片")]
        public byte[] Picture { get; set; }        
    }

    public class MetaProducts
    {
        //主鍵
        [DisplayName("產品編號")]
        public int ProductID { get; set; }

        [DisplayName("產品名稱")]
        public string ProductName { get; set; }

        //外來鍵是否要驗證?，在VIEW表單中為下拉式選單
        //[DataType(DataType.)]   //內建的規則，就可以不用寫正規表達式
        [DisplayName("供應商編號")]        
        public Nullable<int> SupplierID { get; set; }

        [DisplayName("類別編號")]
        //外來鍵是否要驗證?
        public Nullable<int> CategoryID { get; set; }


        [DisplayName("產品單位")]
        public string QuantityPerUnit { get; set; }

        //可以有小數
        [DisplayName("產品單價")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "必須大於0")]
        public Nullable<decimal> UnitPrice { get; set; }


        [DisplayName("庫存量")]
        [Range(0, short.MaxValue, ErrorMessage = "必須大於0")]
        public Nullable<short> UnitsInStock { get; set; }


        [DisplayName("已採購量")]
        [Range(0, short.MaxValue, ErrorMessage = "必須大於0")]
        public Nullable<short> UnitsOnOrder { get; set; }


        [Range(0, short.MaxValue, ErrorMessage = "必須大於0")]
        [DisplayName("安全存量")]
        public Nullable<short> ReorderLevel { get; set; }

        [DisplayName("是否銷售")]
        [DefaultValue(false)]   //預設值
        public bool Discontinued { get; set; }        
    }

     public class MetaCustomers
    {
        [DisplayName("顧客編號")]
        public string CustomerID { get; set; }

        [DisplayName("公司名稱")]
        public string CompanyName { get; set; }

        [DisplayName("聯絡人姓名")]
        public string ContactName { get; set; }

        [DisplayName("聯絡人職稱")]
        public string ContactTitle { get; set; }

        [DisplayName("地址")]
        public string Address { get; set; }

        [DisplayName("城市")]
        public string City { get; set; }

        [DisplayName("區域")]
        public string Region { get; set; }

        [DisplayName("郵遞區號")]
        public string PostalCode { get; set; }

        [DisplayName("國家")]
        public string Country { get; set; }

        [DisplayName("連絡電話")]
        public string Phone { get; set; }

        [DisplayName("傳真")]
        public string Fax { get; set; }
    }

}