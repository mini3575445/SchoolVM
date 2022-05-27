using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class MultiFileUpLoadController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photo)
        {
            if (photo != null)
            {
                for (int i = 0; i < photo.Length; i++)
                {
                    if (photo[i].ContentLength > 0)
                    {
                        photo[i].SaveAs(Server.MapPath("~/Photos/" + photo[i].FileName));
                        ViewBag.Message = "上傳成功!!";
                    }
                }
            }
            else
            {
                ViewBag.Message = "您沒有上傳任何檔案!!";
            }
            return View();
        }

        public string ShowPhoto()
        {
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/Photos/"));
            FileInfo[] files = d.GetFiles();


            string show = "";

            foreach (FileInfo item in files)
            {
                show += "<img src='../Photos/" + item.Name + "' />";
            }

            show += "<hr><a href='/MultiFileUpLoad/Create'>點我回上傳照片頁面</a>";
            return show;

        }
    }
}