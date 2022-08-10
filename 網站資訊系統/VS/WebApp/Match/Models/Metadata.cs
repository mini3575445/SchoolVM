﻿namespace Match.Models
{
    using System;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using System.Security.Cryptography;
    public class MetaActivity
    {
        [DisplayName("活動編號")]
        [Key]
        [RegularExpression("^[A][0-9]{5}$")]
        public string activity_id { get; set; }

        [DisplayName("類型編號")]
        [Required]
        [RegularExpression("^[C][0-9]{2}$")]
        public string activity_type_id { get; set; }

        [DisplayName("活動名稱")]
        [Required]
        [StringLength(50)]
        public string activity_name { get; set; }

        [DisplayName("活動日期")]
        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime activity_datetime { get; set; }

        [DisplayName("地點編號")]
        [Required]
        [RegularExpression("^[S][0-9]{5}$")]
        public string place_id { get; set; }

        [DisplayName("發起人編號")]
        [Required]
        [RegularExpression("^[P][0-9]{5}$")]
        public string member_id { get; set; }
    }

    public class MetaActivity_detail
    {
        [DisplayName("流水號")]
        [Key]
        [RegularExpression("^[A][0-9]{12}$")]
        public string activity_detail_number { get; set; }

        [DisplayName("活動編號")]
        [RegularExpression("^[A][0-9]{5}$")]
        [Required]
        public string activity_id { get; set; }

        [DisplayName("參加者")]
        [RegularExpression("^[P][0-9]{5}$")]
        [Required]
        public string member_id { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Member Member { get; set; }
    }

    public class MetaActivity_type
    {
        [DisplayName("類型編號")]
        [Key]
        [RegularExpression("^[C][0-9]{2}$")]
        public string activity_type_id { get; set; }

        [DisplayName("類型名稱")]
        [StringLength(50)]
        public string activity_type_name { get; set; }
    }
    public class MetaFriend
    {

        [DisplayName("流水號")]
        [Key]
        [RegularExpression("^[E][0-9]{2}$")]
        public string friend_number { get; set; }

        [DisplayName("使用者")]
        [RegularExpression("^[P][0-9]{5}$")]
        [Required]
        public string friend_member1 { get; set; }

        [DisplayName("好友")]
        [RegularExpression("^[P][0-9]{5}$")]
        [Required]
        public string friend_member2 { get; set; }
    }

    public class MetaMember
    {

        [DisplayName("會員編號")]
        [Key]
        [RegularExpression("^[P][0-9]{5}$")]
        public string member_id { get; set; }

        [DisplayName("帳號")]
        [RegularExpression("^[A-Za-z0-9]{6,30}$")]
        [Required]
        public string member_account { get; set; }

        public string member_password { get; set; }

        ////***member_password的get、set要貼到Member.cs運作
        //string password;
        //[DisplayName("密碼")]
        //[Required]
        //[DataType(DataType.Password)]

        //public string member_password
        //{
        //    get
        //    {
        //        return password;
        //    }
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


        //string password;
        //[DisplayName("密碼")]
        //[DataType(DataType.Password)]
        //[Required]
        ////[RegularExpression("^[A-Za-z0-9]{6,30}$")]
        //public string member_password         
        //{  
        //    get { return password; } 

        //   set 
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

    public class MetaPlace
    {

        [DisplayName("活動地點編號")]
        [Key]
        [RegularExpression("^[S][0-9]{5}$")]
        public string place_id { get; set; }

        [DisplayName("活動地點分類編號")]
        [RegularExpression("^[E][0-9]{2}$")]
        [Required]
        public string place_type_id { get; set; }

        [DisplayName("店家名稱")]
        [StringLength(50)]
        [Required]
        public string shop_name { get; set; }

        [DisplayName("地址")]
        [StringLength(100)]
        [Required]
        public string place_address { get; set; }

        [DisplayName("聯絡電話")]
        [StringLength(10)]
        [Required]
        public string place_phone { get; set; }

        [DisplayName("營業時間")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> place_hours_start { get; set; }

        [DisplayName("結束時間")]
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> place_hours_end { get; set; }
    }

    public class MetaPlace_off_day
    {
        [DisplayName("流水號")]
        [Key]
        public int place_off_day_number { get; set; }

        [DisplayName("活動地點編號")]
        [RegularExpression("^[S][0-9]{5}$")]
        [Required]
        public string place_id { get; set; }

        [DisplayName("公休日")]
        [RegularExpression("^[\u4e00\u4e8c\u4e09\u56db\u4e94\u516d\u65e5]$")]
        public string place_off_day1 { get; set; }
    }

    public class MetaPlace_type
    {
        [DisplayName("分類編號")]
        [Key]
        [RegularExpression("^[E][0-9]{2}$")]

        public string place_type_id { get; set; }

        [DisplayName("分類名稱")]
        [StringLength(50)]
        public string place_type_name { get; set; }
    }

    public class MetaRight
    {
        [DisplayName("權限編號")]
        [RegularExpression("^[A-Z]$")]
        [Key]
        public string right_id { get; set; }
        [DisplayName("權限名稱")]
        [StringLength(50)]
        [Required]
        public string right_name { get; set; }
    }
}