using System;
using System.ComponentModel.DataAnnotations;

namespace _05CustomValidator.Models
{
    //如何驗證是否有重複的資料
    public class Member
    {
        [Key]
        public int id { get; set; }

        [Required]
        [RegularExpression("[A-Z][12][0-9]{8}")]
        [CheckIDNumber(ErrorMessage = "來亂?")]
        public string IDNmber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        //：為繼承(擁有父類別全部的東西
        //CheckIDNumber繼承ValidationAttribute驗證屬性
        public class CheckIDNumber : ValidationAttribute
        {
            //override 覆蓋
            //IsValid功能就是有沒有驗證通過，但它裡面是空的，規則要自己寫
            public override bool IsValid(object value)
            {

                string id = value.ToString();//A123456789

                //const常數
                const string eng = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
                string t = id.Substring(0, 1);  //t="A"
                int intEng = eng.IndexOf(t) + 10;   //A=10



                // total
                // 10/10 得到十位數
                // 10%10 得到個位數
                int total = intEng / 10 * 1 + intEng % 10 * 9;



                int[] numId = new int[9];

                for (int i = 0; i < 9; i++)
                {
                    numId[i] = Convert.ToInt32(id.Substring(i + 1, 1));
                }
                total += numId[0] * 8 + numId[1] * 7 + numId[2] * 6 + numId[3] * 5 + numId[4] * 4 + numId[5] * 3 + numId[6] * 2 + numId[7] * 1 + +numId[8] * 1;



                // 除餘 10 == 0 ture else false
                if (total % 10 == 0)
                    return true;

                return false;













            }
        }


    }
}