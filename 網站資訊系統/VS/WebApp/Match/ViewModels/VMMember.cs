using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Match.Models
{
    public class VMMember
    {
        [DisplayName("會員編號")]
        [Key]
        [RegularExpression("^[P][0-9]{5}$")]
        public string member_id { get; set; }

        [DisplayName("帳號")]
        [RegularExpression("^[A-Za-z0-9]{6,30}$")]
        [Required]
        public string member_account { get; set; }

        [DisplayName("密碼")]
        public string member_password { get; set; }

        //string password;
        //[DisplayName("密碼")]
        //[DataType(DataType.Password)]
        //[Required]
        ////[RegularExpression("^[A-Za-z0-9]{6,30}$")]
        //public string member_password
        //{
        //    get { return password; }
        //    set
        //    {
        //        byte[] hashValue;
        //        string result = "";

        //        System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();
        //        byte[] pwBytes = ue.GetBytes(value);
        //        SHA256 shHash = SHA256.Create();
        //        hashValue = shHash.ComputeHash(pwBytes);
        //        foreach (byte b in hashValue)
        //        {
        //            result += b.ToString();
        //        }
        //        password = result;
        //    }
        //}

        [DisplayName("確認密碼")]
        [RegularExpression("^[A-Za-z0-9]{6,30}$")]
        [DataType(DataType.Password)]
        [Required]
        [Compare("member_password", ErrorMessage = "兩次輸入不同")]
        public string confirm_member_password { get; set; }


        [DisplayName("會員名稱")]
        [StringLength(50)]
        [Required]
        public string member_name { get; set; }

        [DisplayName("姓名")]
        [StringLength(20)]
        [Required]
        public string member_id_name { get; set; }

        [DisplayName("性別")]
        [Required]
        //[RegularExpression("^[01]$")]
        public bool member_gender { get; set; }

        [DisplayName("生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required]
        public System.DateTime member_birthday { get; set; }


        [DisplayName("手機號碼")]
        [RegularExpression("^[0][9][0-9]{8}$")]
        [Required]
        public string member_cellphone { get; set; }

        [DisplayName("電子信箱")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(50)]
        [Required]
        public string member_email { get; set; }

        [DisplayName("通訊地址")]
        [StringLength(100)]
        [Required]
        public string member_address { get; set; }

        [DisplayName("權限編號")]
        [RegularExpression("^[A-Z]$")]
        [Required]
        public string right_id { get; set; }

    }
}