using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace HW5.Models
{
    public class Member
    {
        [Key] //唯一識別值
        public int ID { get; set; }

        [Required]  //必填
        [RegularExpression("[A-Z][12][0-9]{8}", ErrorMessage = "第一碼需為英文大寫，第二碼須為1、2，第三碼到第十碼需為0~9")]
        [CheckIDNumber]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public class CheckIDNumber : ValidationAttribute 
        {
            public CheckIDNumber() 
            {
                ErrorMessage = "身分證字號格式不符";
            }

            public override bool IsValid(object value)
            {
                //身分證字號傳入為物件所以轉字串
                string id = value.ToString();   //A123456789
                const string eng = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
                string s = id.Substring(0, 1); //s1=A
                int intEng = eng.IndexOf(s) + 10; //A=10
                int n1 = intEng / 10;
                int n2 = intEng % 10;

                //抓1~9轉為int放入陣列
                int[] ary = new int[9];
                for (int i = 0; i < 9; i++)
                { 
                    ary[i]= Convert.ToInt32(id.Substring(i+1, 1));
                }

                int sum = 0;
                sum += n1 + (n2 * 9);   //A
                
                for (int j = 0; j < 8; j++) //1~8
                {
                    sum += ary[j] * (8 - j);    //sum += 1 * 8
                }

                sum += ary[8];  //9

                
                if (sum % 10 == 0) return true;


                return false;
            }
        }
    }
}