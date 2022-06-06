using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03Model.Models;

namespace _03Model.Controllers
{
    public class HomeController : Controller
    {
        //LinQ可以對任何資料結構使用
        public string ShowAryDesc()
        {
            int[] score = {78,90,20,100,66 };
            string show = "";

            //LinQ查詢運算是寫法(最原生)
            //這邊的result是泛型
            //var result = from s in score    //s等於foreach item in score
            //             orderby s descending
            //             select s;

            //LinQ擴充方法寫法
            var result = score.OrderByDescending(s => s);


            //SQL
            //select s from score order by s desc
            foreach (var item in result)
            {
                show += item + ", ";
            }

            return show;

            //var result = from s in score
            //             orderby s
            //             select s;       

            
            
        }
        public string LoginMember(string uid,string pwd)
        {
            //Member member = new Member();
            //member.UId = "tom";
            //member.Pwd = "123";
            //member.Name = "湯姆";

            //Member member2 = new Member();
            //member2.UId = "jsper";
            //member2.Pwd = "456";
            //member2.Name = "賈斯柏";

            //Member member3 = new Member();
            //member3.UId = "mary";
            //member3.Pwd = "789";
            //member3.Name = "瑪莉";

            Member[] members = new Member[3]
            {
                new Member{UId="tom",Pwd="123",Name="湯姆"},
                new Member{UId="jsper",Pwd="456",Name="賈斯柏"},
                new Member{UId="mary",Pwd="789",Name="瑪麗"},
            };
            //SQL
            //select * from members where UId='tom' and Pwd='123'

            //LinQ
            var result = (from m in members
                          where m.UId == uid && m.Pwd == pwd
                          select m).FirstOrDefault();
            //FirstOrDefault結果不能為多個值

            //Linq擴充方法的寫法
            //var result = members.Where(m => m.UId == uid && m.Pwd == pwd).FirstOrDefault();
            
            
            string show = "";
            if (result != null)
            {
                show = "歡迎" + result.Name + "登入約跑系統";
            }
            else
            {
                show = "帳號或密碼錯誤";
            }

                return show;
        }
       
    }
}