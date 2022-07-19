using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW7Project.Models
{
    public class VMLogin
    {
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, ErrorMessage = "長度不超過20字元")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}")]//最少4次，最多19次
        [DisplayName("帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [MaxLength(20, ErrorMessage = "最大長度為20字元")]
        [MinLength(8, ErrorMessage = "最小長度為8字元")]
        [DataType(DataType.Password)]
        [DisplayName("密碼")]
        public string Password { get; set; }
    }
}