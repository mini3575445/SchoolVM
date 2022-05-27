using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _001controller.Controllers
{
    public class MultFileUpLoadController : Controller
    {
        // GET: MultFileUpLoad
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photo)    //檔案傳輸的物件
        {
            if (photo != null)
            {
                for (int i = 0; i < photo.Length; i++)
                {
                    if (photo[i].ContentLength > 0) //ContentLength上傳的檔案大小
                    {
                        photo[i].SaveAs(Server.MapPath("~/Photos/" + photo[i].FileName));
                        ViewBag.Message = "上傳成功!!";
                        //SaveAs儲存檔案的方法
                        //MapPath邏輯路徑對應實體路徑:DomainName對應D:\SchoolVM\網站資訊系統\VS\WebApp\001controller\Photos                                      
                    }
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
            foreach (FileInfo item in files)
            {
                show += "<img src='../Photos/" + item.Name + "'>";
            }
            return show;
        }
    }
}