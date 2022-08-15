using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Security.Cryptography;


namespace HW7Project.Models
{
    public class Members
    {
        //若有ViewModel，就只要寫跟資料庫有關的驗證就好了。
        [Key]
        [DisplayName("會員編號")]
        public int MemberID { get; set; }

        [DisplayName("姓名")]
        [StringLength(100)]
        [Required]      
        public string MemberName { get; set; }

        
        [DisplayName("照片")]
        [MaxLength]
        public string MemberPhotoFile { get; set; }

        [DisplayName("生日")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime MemberBirdthday { get; set; }

        [DisplayName("建立日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }


        [DisplayName("帳號")]
        [Required]
        [StringLength(20)]
        [CheckAccount(ErrorMessage ="已經有相同帳號")]
        public string Account { get; set; }




        //***封裝:{get;set;}
        string password;    //定義一個password的field，欄位
        [Required]
        [DataType(DataType.Password)]   //view上就會把密碼蓋起來
        [DisplayName("密碼")]
        public string Password  //屬性
        {
            //讀取
            get 
            {
                return password;    //這個是string password;
            }

            //寫入
            set
            {
                //***密碼的雜湊，用某種運算方式轉成暗碼
                //為甚麼要做雜湊
                //密碼是string，進到資料庫後可以看到所有人密碼
                byte[] hashValue;
                string result = "";

                System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();

                byte[] pwBytes = ue.GetBytes(value);

                SHA256 shHash = SHA256.Create();

                hashValue = shHash.ComputeHash(pwBytes);    

                foreach (byte b in hashValue)
                {
                    result += b.ToString();
                }
                password = result;
            }
        
        }


        //新增會員的確認密碼怎麼做
        //1.直接在View上增加一個欄位，在前端驗證
        //2.建立ViweModel並新增一個確認密碼的屬性(實務上都這麼做)

        //***自訂驗證

        public class CheckAccount : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
               HW7ProjectContext db = new HW7ProjectContext();

               var account = db.Members.Where(m => m.Account == value.ToString()).FirstOrDefault();


                return (account==null)? true : false;
            }


        }



    }
}