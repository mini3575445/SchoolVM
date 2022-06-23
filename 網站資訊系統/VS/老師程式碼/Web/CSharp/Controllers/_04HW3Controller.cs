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


        public void DealCard()
        {
            //1.弄一副牌出來(放到陣列中)
            string[] poker = new string[52];  //宣告52個元素大小的陣列,索引值為0~51

            for(int i = 0; i < poker.Length; i++)
            {
                poker[i] = (i+1).ToString();
            }

            //測試用
            //foreach(var item in poker)
            //{
            //    Response.Write("<img src='../poker_img/"+item+".gif' />");
            //}


            //洗牌
            Random r = new Random();
            int temp = 0;
            string t = "";
            for (var j = 0; j < 5; j++)
            {
                for (int i = 0; i < poker.Length; i++)
                {
                    temp = r.Next(52);//取一個亂數值
                    t = poker[i];
                    poker[i] = poker[temp];
                    poker[temp] = t;

                }
            }
            //測試用
            //foreach (var item in poker)
            //{
            //    Response.Write("<img src='../poker_img/" + item + ".gif' />");
            //}
            //Response.Write("<hr>");

            //3.發牌(把陣列中的元素依序顯示)
            string p1 = "", p2 = "", p3 = "", p4 = "";
            string result = "";
            for(var i=0;i<poker.Length;i++)
            {
                result = "<img src='../poker_img/" + poker[i] + ".gif' />";

                switch (i%4)
                {
                    case 0:
                        p1 += result;
                        break;
                    case 1:
                        p2 += result;
                        break;
                    case 2:
                        p3 += result;
                        break;
                    case 3:
                        p4 += result;
                        break;
                }

            }

            Response.Write("玩家1:" + p1+"<br />");
            Response.Write("玩家2:" + p2 + "<br />");
            Response.Write("玩家3:" + p3 + "<br />");
            Response.Write("玩家4:" + p4 + "<br />");

        }
    }
}