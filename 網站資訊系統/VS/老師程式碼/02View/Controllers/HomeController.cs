using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02View.Models;

namespace _02View.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };

            string[] name = { "瑞豐夜市", "新堀江商圈", "六合夜市", "青年夜市", "花園夜市", "大東夜市", "武聖夜市" };

            string[] address = { "813高雄市左營區裕誠路", "800高雄市新興區玉衡里", "800台灣高雄市新興區六合二路",
                "80652高雄市前鎮區凱旋四路758號", "台南市北區海安路三段533號", "台南市東區林森路一段276號",
                "台南市中西區武聖路69巷42號" };


            List<NightMarket> list = new List<NightMarket>();
            NightMarket nm;


            for (int i=0;i < id.Length; i++)
            {
                nm = new NightMarket();

                nm.Id= id[i];
                nm.Name= name[i];
                nm.Address= address[i];

                list.Add(nm);
            }

         

            return View(list);
        }
        public ActionResult Boostrap()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };

            string[] name = { "瑞豐夜市", "新堀江商圈", "六合夜市", "青年夜市", "花園夜市", "大東夜市", "武聖夜市" };

            string[] address = { "813高雄市左營區裕誠路", "800高雄市新興區玉衡里", "800台灣高雄市新興區六合二路",
                "80652高雄市前鎮區凱旋四路758號", "台南市北區海安路三段533號", "台南市東區林森路一段276號",
                "台南市中西區武聖路69巷42號" };


            List<NightMarket> list = new List<NightMarket>();
            NightMarket nm;


            for (int i = 0; i < id.Length; i++)
            {
                nm = new NightMarket();

                nm.Id = id[i];
                nm.Name = name[i];
                nm.Address = address[i];

                list.Add(nm);
            }



            return View(list);
        }
        //03-3-1 在Home Controller 建立Detail Action
        public ActionResult Details(string NMid)
        {
            ViewBag.ID = NMid;

            //select * from NightMarket where id='A01'

            return View();
        }

        public ActionResult Razor()
        {
            return View();
        }

    }
}

//03-1 建立一個顯示各大夜市的View
//03-1-1 在Models上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入NightMarket.cs
//03-1-2 在NightMarket class中輸入下列欄位以建立Model
//03-1-3 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5控制器-空白
//03-1-4 指定控制器名稱為HomeController,並開啟HomeController
//03-1-5 using _02View.Models
//03-1-6 在public ActionResult Index()內輸入內容
//03-1-7 在public ActionResult Index()上按右鍵,新增檢視
//03-1-8 進行下列設定:
//       檢視名稱:Index
//       範本:List
//       模型:NightMarket(02View.Models) 
//       勾選 使用板版面配置頁
//       按下 加入

//03-2 NightMarket View
//03-2-1 修改英文標題為中文,修改<th>標籤內容為中文字
//03-2-2 增加item.Id, 並將最後一欄註解
//03-2-3 執行以測試結果
//03-2-4 增加兩項<th>標籤
//03-2-5 讀取圖片檔名
//03-2-6 增加圖片及地圖顯示

//03-3 Detail頁面的觀念
//03-3-1 在Home Controller 建立Details Action
//03-3-2 在public ActionResult Details()上按右鍵,新增檢視
//03-3-3 進行下列設定:
//       檢視名稱:Details
//       範本:Empty (沒有模型)
//       勾選 使用板版面配置頁
//       按下 加入
//03-3-4 在Details 上讀出ViewBag的值
//03-3-5 觀察url上參數值與ViewBag的值


//03-4 Razor語法
//03-4-1 在Home Controller 新增RazorTest() Action
//03-4-2 在public ActionResult RazorTest()上按右鍵,新增檢視
//03-4-3 進行下列設定:
//       檢視名稱:RazorTest
//       範本:Empty (沒有模型)
//       勾選 使用板版面配置頁
//       按下 加入
//03-4-4 Razor語法練習


//03-5 HTML Helper
//03-5-1 在Models上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入Member.cs
//03-5-2 在Member class中輸入下列欄位以建立Model
//03-5-3 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-空白
//03-5-4 指定控制器名稱為HTMLHelperController,並開啟HTMLHelperController
//03-5-5 using _02View.Models
//03-5-6 建立GET與POST的Create方法
//03-5-7 在public ActionResult Create()上按右鍵,新增檢視
//03-5-8 進行下列設定:
//       檢視名稱:Create
//       範本:Create
//       模型:Member(02View.Models) 
//       勾選 使用板版面配置頁
//       按下 加入
//03-5-9 撰寫HTMLHelper/Create View 內容
//03-5-10 執行以測試結果


//03-7 前台版面-利用Boostrap實現RWD(響應式網頁)
//03-7-1 在Home Controller 建立Bootstrap Action
//03-7-2 將Index Action的內容貼到Bootstrap Action
//03-7-3 建立Bootstrap Action的View
//03-7-4 在public ActionResult Bootstrap()內輸入內容
//03-7-5 在public ActionResult Bootstrap()上按右鍵,新增檢視
//03-7-6 進行下列設定:
//       檢視名稱: Bootstrap
//       範本:Empty
//       模型:NightMarket(02View.Models) 
//       勾選 使用板版面配置頁
//       按下 加入
//03-7-7 編輯Bootstrap View