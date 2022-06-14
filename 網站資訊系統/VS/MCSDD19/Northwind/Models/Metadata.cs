
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
        
        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(40, ErrorMessage = "最多40字元")]
        public string ProductName { get; set; }

        //外來鍵是否要驗證?，在VIEW表單中為下拉式選單
        //[DataType(DataType.)]   //內建的規則，就可以不用寫正規表達式
        [DisplayName("供應商編號")]        
        public int SupplierID { get; set; }

        [DisplayName("產品類別")]
        //外來鍵
        public int CategoryID { get; set; }


        [DisplayName("產品單位")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "最多20字元")]
        public string QuantityPerUnit { get; set; }

        //可以有小數
        [DisplayName("產品單價")]
        [Required(ErrorMessage = "必填欄位")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "必須大於0")]
        public decimal UnitPrice { get; set; }  //把原本的泛型改成純資料，因為泛型可以為空值


        [DisplayName("庫存量")]
        [Required(ErrorMessage = "必填欄位")]
        [Range(0, short.MaxValue, ErrorMessage = "必須大於0")]
        public short UnitsInStock { get; set; }


        [DisplayName("已採購量")]
        [Required(ErrorMessage = "必填欄位")]
        [Range(0, short.MaxValue, ErrorMessage = "必須大於0")]
        public short UnitsOnOrder { get; set; }


        
        [DisplayName("安全存量")]
        [Required(ErrorMessage = "必填欄位")]
        [Range(0, short.MaxValue, ErrorMessage = "必須大於0")]
        public short ReorderLevel { get; set; }

        [DisplayName("是否銷售")]
        [DefaultValue(false)]   //預設值
        public bool Discontinued { get; set; }        
    }

    public class MetaCustomers
    {
        [Key]
        [DisplayName("顧客編號")]
        [RegularExpression("[A-Z]{5}")]
        //nchar(5)
        public string CustomerID { get; set; }

        [DisplayName("公司名稱")]
        [Required]
        [StringLength(40,ErrorMessage ="最多40字元")]
        public string CompanyName { get; set; }

        [DisplayName("聯絡人姓名")]
        [StringLength(30, ErrorMessage = "最多30字元")]
        public string ContactName { get; set; }

        [DisplayName("聯絡人職稱")]
        [StringLength(30, ErrorMessage = "最多30字元")]
        public string ContactTitle { get; set; }

        [DisplayName("地址")]
        [StringLength(60, ErrorMessage = "最多60字元")]
        public string Address { get; set; }

        [DisplayName("城市")]
        [StringLength(15, ErrorMessage = "最多15字元")]
        public string City { get; set; }

        [DisplayName("區域")]
        [StringLength(15, ErrorMessage = "最多15字元")]
        public string Region { get; set; }

        [DisplayName("郵遞區號")]
        [StringLength(10, ErrorMessage = "最多10字元")]
        public string PostalCode { get; set; }

        [DisplayName("國家")]
        [StringLength(15, ErrorMessage = "最多15字元")]
        public string Country { get; set; }

        [DisplayName("連絡電話")]
        [StringLength(24, ErrorMessage = "最多24字元")]
        public string Phone { get; set; }

        [DisplayName("傳真")]
        [StringLength(24, ErrorMessage = "最多24字元")]
        public string Fax { get; set; }
    }

}