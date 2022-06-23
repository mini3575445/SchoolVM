using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//02-4-4 using System.IO
using System.IO;


namespace _01Controller.Controllers
{
    public class FileUpLoadController : Controller
    {
        //02-4-5 建立GET與POST的Create方法
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                if (photo.ContentLength > 0) 
                { 
                    photo.SaveAs(Server.MapPath("~/Photos/" + photo.FileName));
                    ViewBag.Message = "上傳成功!!";
                }
            }
            else
            {
                ViewBag.Message = "您沒有上傳任何檔案!!";
            }
            return View();
        }

        //02-4-6 建立ShowPhotos()一般方法-可顯示Photos資料夾下所有圖檔
        public string ShowPhoto()
        {
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/Photos/"));
            FileInfo[] files = d.GetFiles();


            string show = "";

            foreach(FileInfo item in files)
            {
                show += "<img src='../Photos/" + item.Name + "' />";
            }

            show += "<hr><a href='/FileUpLoad/Create'>點我回上傳照片頁面</a>";
            return show;
           
        }
    }
}