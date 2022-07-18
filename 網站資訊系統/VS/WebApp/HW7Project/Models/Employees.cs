using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW7Project.Models
{
    public class Employees
    {
        //這個動作叫做封裝
        [Key]   //資料庫就會把它設為PK
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [StringLength(100, ErrorMessage = "長度不超過100字元")]
        [DisplayName("員工姓名")]
        public string EmployeeName { get; set; }

        [DisplayName("建立日期")]
        [DataType(DataType.Date)]   //這是給View看的
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]    //設定日期格式預設為2022/7/18 09:12:00，ApplyFormatInEditMode一併套用至所有區域
        public DateTime CreatedDate { get; set; }
        
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "長度不超過20字元")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}")]//最少4次，最多19次
        [DisplayName("帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [MaxLength(20,ErrorMessage ="最大長度為20字元")]
        [MinLength(8, ErrorMessage = "最小長度為8字元")]
        [DataType(DataType.Password)]
        [DisplayName("密碼")]
        public string Password { get; set; }
    }
}