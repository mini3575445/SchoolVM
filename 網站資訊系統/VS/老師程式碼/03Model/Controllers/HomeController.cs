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
        //04-1-3 建立一般方法ShowAryDesc()-整數陣列遞減排序
        public string ShowAryDesc()
        {
            int[] score = { 78, 90, 20, 100, 66 };

            string show = "";

            //Linq查詢運算式寫法
            //var result = from s in score
            //             orderby s descending
            //             select s;

            //Linq擴充方法的寫法
            var result = score.OrderByDescending(s => s);

            //SQL
            //select s from score order by s desc

            foreach (var item in result)
            {
                show += item+", ";   
            }

            return show;


        }

        //04-1-5 建立一般方法ShowAryAsc()-整數陣列遞增排序
        public string ShowAryAsc()
        {
            int[] score = { 78, 90, 20, 100, 66 };

            string show = "";

            //Linq查詢運算式寫法
            //var result = from s in score
            //             orderby s ascending
            //             select s;

            //Linq擴充方法的寫法
            var result = score.OrderBy(s => s);

            //SQL
            //select s from score order by s

            foreach (var item in result)
            {
                show += item + ", ";
            }
            show += "<hr>";
            show += "成績平均" + result.Average();
            show += "<hr>";
            show += "成績總和" + result.Sum();

            return show;


        }

        public string LoginMember(string uid, string pwd)
        {
            //Member member = new Member();
            //member.UId = "tom";
            //member.Pwd = "123";
            //member.Name = "湯姆";

            //Member member2 = new Member();
            //member2.UId = "jsper";
            //member2.Pwd = "456";
            //member2.Name = "賈斯伯";

            //Member member3 = new Member();
            //member3.UId = "mary";
            //member3.Pwd = "789";
            //member3.Name = "瑪麗";

            Member[] members = new Member[]
            {
                new Member{ UId="tom",Pwd="123",Name="湯姆"},
                new Member{ UId="jsper",Pwd="456",Name="賈斯伯"},
                new Member{ UId="mary",Pwd="789",Name="瑪麗"}
            };

            //SQL
            //select * from members where UId='tom' and Pwd='123'



            //Linq查詢運算式寫法
            //var result = (from m in members
            //              where m.UId == uid && m.Pwd == pwd
            //              select m).FirstOrDefault();

            //Linq擴充方法的寫法
            var result = members.Where(m => m.UId == uid && m.Pwd == pwd).FirstOrDefault();

            string show = "";
            if (result != null)
            {
                show = "歡迎" + result.Name + "進入本系統";

            }
            else
                show = "帳號或密碼錯誤!";

            return show;
        }


    }
}

//04-1 Linq練習
//04-1-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-空白
//04-1-2 指定控制器名稱為HomeController,並開啟HomeController
//04-1-3 建立一般方法ShowAryDesc()-整數陣列遞減排序
//04-1-4 執行並測試 http://localhost:53468/Home/ShowAryDesc (port可能不同)
//04-1-5 建立一般方法ShowAryAsc()-整數陣列遞增排序
//04-1-6 執行並測試 http://localhost:53468/Home/ShowAryAsc (port可能不同)
//04-1-7 在Controllers資料夾上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入Member.cs
//04-1-8 在Member class中輸入下列欄位
//04-1-9 在HomeController中建立一般方法LoginMember()
//04-1-10 執行並測試 http://localhost:53468/Home/LoginMember?uid=tom&pwd=123 (port可能不同)


//04-2 Entity FrameWork
//04-2-1 建立NorthWind.mdb資料庫Model
//       在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//       來自資料庫的EF Designer
//       連接NorthWind.mdf資料庫,連線名稱不修改,按下一步按鈕
//       選擇Entity Framework 6.x, 按下一步按鈕
//       資料表"全選", 按完成鈕
//       若跳出詢問方法按確定鈕
//04-2-3 在專案上按右鍵,建置
//04-2-4 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-空白
//04-2-5 指定控制器名稱為LinqController,並開啟LinqController
//04-2-6 using _03EF.Model
//04-2-7 於LinqController建立DB物件
//04-2-8 建立一般方法ShowEmployee()-查詢所有員工記錄
//04-2-9 執行並測試 http://localhost:53468/Home/ShowEmployee (port可能不同)
//04-2-10 建立一般方法ShowCustomerByAddress()-找出客戶地址中含有keyword關鍵字的客戶記錄
//04-2-11 執行並測試 http://localhost:53468/Home/ShowCustomerByAddress?keywork=xxxxx (port可能不同)
//04-2-12 建立一般方法ShowProduct()-查詢單價大於30的產品，並依單價做遞增排序，庫存量做遞減排序
//04-2-13 執行並測試 http://localhost:53468/Home/ShowProduct (port可能不同)
//04-2-14 建立一般方法ShowProductInfo()-查詢產品平均價、總合、筆數，最高價和最低價資訊
//04-2-15 執行並測試 http://localhost:53468/Home/ShowProductInfo (port可能不同)


//04-3 在Model建立驗證功能
//04-3-1 建立dbStudent.mdb資料庫Model
//       在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//       來自資料庫的EF Designer
//       連接dbStudent.mdf資料庫,連線名稱不修改,按下一步按鈕
//       選擇Entity Framework 6.x, 按下一步按鈕
//       資料表"全選", 按完成鈕
//       若跳出詢問方法按確定鈕
//04-3-2 在專案上按右鍵,建置
//04-3-3 展開dbStudentModel.edmx, 再展開dbStudentModel.tt, 找到tStudent.cs並開啟此檔
//04-3-4 using System.ComponentModel 及 System.ComponentModel.DataAnnotations
//04-3-5 在原程式中加入驗證功能標籤 


//04-3-6 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-空白
//04-3-7 指定控制器名稱為DefualtController,並開啟DefualtController
//04-3-8 using _03Model.Models
//04-3-9 於DefualtController建立DB物件,並撰寫Index、Create、Delete的Action
//04-3-10 在public ActionResult Index()上按右鍵,新增檢視,建立Index View
//04-3-10-1 進入NuGet套件管理,將Entity Framework zh-hant移除
//04-3-11 進行下列設定:
//        檢視名稱:Index
//        範本:List
//        模型類別:tStudent(_03Model.Models)
//        資料內容類別:dbStudentEntities(_03Model.Models)
//        勾選 使用版片配置頁
//        按下 加入
//04-3-12 修改英文文字為中文與表格中的內容
//04-3-13 執行並測試
//04-3-14 在public ActionResult Create()上按右鍵,新增檢視,建立Create View
//04-3-15 進行下列設定:
//        檢視名稱:Create
//        範本:Create
//        模型類別:tStudent(_03Model.Models)
//        資料內容類別:dbStudentEntities(_03Model.Models)
//        勾選 使用版片配置頁
//        按下 加入
//04-3-16 修改英文文字為中文
//04-3-17 執行並測試
//04-3-18 安裝驗證相關套件
//套件1:jquery.validation
//套件2:Microsoft.jQuery.Unobtrusive.Validation
//04-3-17 再執行並測試

//04-4   建立資料新增與刪除的功能
//04-4-1 建立HttpPost Create() Action
//04-4-2 執行新增資料測試
//04-4-3 建立Delete() Action
//04-4-4 編修Index View裡的Delete超連結
//04-4-5 執行刪除資料測試