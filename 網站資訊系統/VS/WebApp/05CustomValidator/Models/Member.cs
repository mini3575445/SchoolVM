using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


//***驗證相關必須於view安裝，才能於前端驗證
//1.jquery
//2.jquery.validate.unobtrusive

namespace _05CustomValidator.Models
{
    public class Member
    {
        //唯一識別值
        [Key]
        public int id { get; set; }

        //1.必填 2.格式正確 3.經過公式能被10整除
        [Required]
        [RegularExpression("[A-Z][12][0-9]{8}")]
        [CheckIDNumber]  //***自訂方法
        public string IDNmber { get; set; }

        //1.必填 2.長度50字元
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        //預設建構子，初始化屬性
        public Member()
        {
            id = 0;
            IDNmber = "";
            Name = "";
        }

        public class CheckIDNumber : ValidationAttribute
        {
            public CheckIDNumber()
            {
                ErrorMessage = "不能被10整除";
            }

            public override bool IsValid(object value)
            {
                int sum = 0;
                string id = value.ToString(); //A123456789

                const string eng = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
                string t = id.Substring(0, 1);  //t="A"
                int intEng = eng.IndexOf(t) + 10;  //A=10

                int n1 = intEng / 10;
                int n2 = intEng % 10;

                int[] a = new int[9];
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = Convert.ToInt32(id.Substring(i + 1, 1));
                }


                //sum= n1 + n2 * 9 + a[0] * 8 + a[1] * 7 + a[2] * 6 + a[3] * 5 + a[4] * 4 + a[5] * 3 + a[6] * 2 + a[7] + a[8];

                sum = n1 + n2 * 9 + a[8];
                //換成迴圈
                for (int i = 0; i < 8; i++)
                {
                    sum += a[i] * (8 - i);
                }

                if (sum % 10 == 0)
                    return true;

                return false;
            }
        }
    }
    
}
