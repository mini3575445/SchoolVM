using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;//檔案傳輸的NameSpace
namespace _001controller.Controllers
{
    public class FileUpLoadController : Controller
    {
        // GET: FileUpLoad
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)    //檔案傳輸的物件
        {
            if (photo != null) { 
                if (photo.ContentLength>0) //ContentLength上傳的檔案大小
                {    
                    photo.SaveAs(Server.MapPath("~/Photos/"+photo.FileName));
                    ViewBag.Message = "上傳成功!!";
                    //SaveAs儲存檔案的方法
                    //MapPath邏輯路徑對應實體路徑:DomainName對應D:\SchoolVM\網站資訊系統\VS\WebApp\001controller\Photos                                      
                }
            }
            else ViewBag.Message = "上傳失敗!!";
            
            return View();
        }

        public string ShowPhoto()
        {
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/Photos/"));
            //DirectoryInfo建立目錄資訊
            FileInfo[] files = d.GetFiles();           //FileInfo[]物件陣列，方法:GetFiles()取得檔案們

            string show = "";
            foreach(FileInfo item in files)
            {
                show += "<img src='../Photos/" + item.Name + "'>";
            }
            return show;
        }
        //上傳檔案的基本防護
        //1.檢查是否有上傳檔案
        //2.限制檔案大小
    }
}