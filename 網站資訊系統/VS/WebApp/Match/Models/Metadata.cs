namespace Match.Models
{
    using System;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
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
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime activity_datetime { get; set; }

        [DisplayName("地點編號")]
        [Required]
        [RegularExpression("^[S][0-9]{5}$")]
        public string place_id { get; set; }

        [DisplayName("發起人編號")]
        [Required]
        [RegularExpression("^[P][0-9]{5}$")]
        public string member_id { get; set; }

        [DisplayName("建立日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime activity_create_date { get; set; }

        [DisplayName("報名截止時間")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime activity_join_deadline { get; set; }

        [DisplayName("人數下限")]
        [Required]
        public int activity_lower { get; set; }

        [DisplayName("人數上限")]
        [Required]
        public int activity_upper { get; set; }

        [DisplayName("活動明細")]
        public string activity_description { get; set; }

        [DisplayName("狀態編號")]
        //[Range(1,9)]
        [Required]
        public int state_id { get; set; }

        ////檢查Upper>=Lower    
        //public class CheckUpper : ValidationAttribute
        //{
        //    public override bool IsValid(object value)
        //    {
                
        //            MatchEntities db = new MatchEntities();

        //            var account = db.Member.Where(m => m.member_account == value.ToString()).FirstOrDefault();

        //            return (account == null) ? true : false;                
        //    }
        //}

    }

    public class MetaActivity_detail
    {
        [DisplayName("流水號")]
        [Key]
        public string activity_detail_number { get; set; }

        [DisplayName("活動編號")]
        [RegularExpression("^[A][0-9]{5}$")]
        [Required]
        public string activity_id { get; set; }

        [DisplayName("參加者")]
        [RegularExpression("^[P][0-9]{5}$")]
        [Required]
        public string member_id { get; set; }

        [DisplayName("參加日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime join_date { get; set; }
    }

    public class MetaActivity_type
    {
        [DisplayName("類型編號")]
        [Key]
        [RegularExpression("^[C][0-9]{2}$")]
        public string activity_type_id { get; set; }

        [DisplayName("類型名稱")]
        [StringLength(50)]
        [CheckActivityTypeName(ErrorMessage ="已經有相同名稱")]
        public string activity_type_name { get; set; }

        public class CheckActivityTypeName : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                MatchEntities db = new MatchEntities();

                var ActivityTypeName = db.Activity_type.Where(m => m.activity_type_name == value.ToString()).FirstOrDefault();

                return (ActivityTypeName == null) ? true : false;
            }
        }
    }
    public class MetaFriend
    {

        [DisplayName("流水號")]
        [Key]
        public int friend_number { get; set; }

        [DisplayName("使用者")]
        [RegularExpression("^[P][0-9]{5}$")]
        [Required]
        public string friend_member1 { get; set; }

        [DisplayName("好友")]
        [RegularExpression("^[P][0-9]{5}$")]
        [Required]
        public string friend_member2 { get; set; }

        [DisplayName("建立日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime friend_create_date { get; set; }


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

        [CheckAccount(ErrorMessage ="已經有相同帳號",flag =false)] //驗證是否有相同帳號

        public string member_account { get; set; }

        [DisplayName("密碼")]
        [Required]
        [DataType(DataType.Password)]
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
        public DateTime member_birthday { get; set; }


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

        [DisplayName("會員照片")]
        public string member_photo_file { get; set; }

        [DisplayName("建立日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime member_create_date { get; set; }


        //檢查重複帳號的自訂驗證        
        public class CheckAccount : ValidationAttribute
        {
            public bool flag = true;

            public override bool IsValid(object value)
            {
                if (flag) 
                { 
                    MatchEntities db = new MatchEntities();

                    var account = db.Member.Where(m=>m.member_account == value.ToString()).FirstOrDefault();

                    return (account == null) ? true : false;
                }
                return true;
            }
        }
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

        //***格式為:高雄市前鎮區博愛一路147號
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

        [DisplayName("建立日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public System.DateTime place_create_date { get; set; }

        [DisplayName("地點照片")]
        public string place_photo_file { get; set; }

        [DisplayName("地點明細")]
        public string place_description { get; set; }

        [DisplayName("是否停業")]
        [Required]
        public bool place_shutdown { get; set; }


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
        [CheckPlaceTypeName(ErrorMessage = "已經有相同名稱")]
        public string place_type_name { get; set; }

        //檢查重複名稱的自訂驗證
        public class CheckPlaceTypeName : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                MatchEntities db = new MatchEntities();

                var placeTypeName = db.Place_type.Where(m => m.place_type_name == value.ToString()).FirstOrDefault();

                return (placeTypeName == null) ? true : false;
            }
        }
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

    public class MetaState
    {
        [DisplayName("狀態編號")]
        [RegularExpression("^[1-9]$")]
        [StringLength(1)]
        [Key]
        public int state_id { get; set; }

        [DisplayName("狀態編號")]
        [StringLength(20)]
        [Required]
        public string state_name { get; set; }
    }
}