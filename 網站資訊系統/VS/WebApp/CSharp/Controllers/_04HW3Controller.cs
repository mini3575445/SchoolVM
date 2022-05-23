using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _04HW3Controller : Controller
    {
        //1.弄一副牌出來(放到陣列中)
        //2.洗牌(把陣列中的元素隨機打亂)
        //3.發牌(把陣列中的元素依序顯示)

        public void Ran(int people) { 
            int number = 0;
            string[] poker = new string[52];//宣告52個元素大小的陣列,索引值為0~51
        Random r = new Random();
        //類別 物件   建構子(建構函數)
        //這是在做鑄造物件(物件要鑄造才能用，js是在Math.Ramdom)(1.有new 2.類別跟建構函數名字相同)
                                                 //物件  方法
        //類別是設計圖、食譜
        //物件是菜
        //建構子是煮菜的方法
        //物件.方法=功能
        //物件.屬性=有甚麼東西
        number = r.Next();
        number = r.Next(0,52);//回傳隨機值:r.Next(包含最小值,不包含最大值)
            //方法(提示為空心紫色物) 

            //1.產生一副牌
            for (int i = 0; i <= 51; i++)
            {
                poker[i] = (i + 1).ToString();  //方法(提示為空心紫色物) 
            }           
            //2.洗牌(迴圈第一個數與隨機索引交換，第二個數與隨機索引交換...)
            string n = "";//暫存交換牌
            int ramIndex = 0;
            for (int i = 0; i <= 51; i++)
            {
                ramIndex = r.Next(0,51);
                n = poker[i];
                poker[i] = poker[ramIndex];
                poker[ramIndex] = n;
            }          
            //3.發牌    
            for (int i = 1; i <= people; i++)
            {
                Response.Write("玩家" +i+":");
                for (int j = i-1; j <= 51; j+=people)
                {
                    Response.Write("<img src='../poker_img/" + poker[j] + ".gif' />");
                }
                Response.Write("<br>");
            }                   
        }

       

    }

}