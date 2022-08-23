using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7Project.Models;

using PagedList; //做分頁的套件

namespace HW7Project.Controllers
{
    //整個Controller都Check
    //[LoginCheck]
    public class MembersController : Controller
    {
        private HW7ProjectContext db = new HW7ProjectContext();

        // GET: Members
        public ActionResult Index(int page=1)
        {
            //分頁功能
            var members = db.Members.ToList();
            int pagesize = 15;
            var pagedList = members.ToPagedList(page, pagesize);    //ToPagedList(目前在第幾頁，每次顯示幾筆)


            return View(pagedList);
        }
        public ActionResult IndexModal()
        {
            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            //***若Detail使用Modal，就能回傳PartialView部分檢視(沒有Layout)
            return View(members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,MemberName,MemberPhotoFile,MemberBirthday,CreatedDate,Account,Password")] Members members, HttpPostedFileBase photo)
        {
            if (photo != null)
            { 
                if(photo.ContentLength>0)
                {
                    string extensionName = System.IO.Path.GetExtension(photo.FileName); //抓副檔名
                    if(extensionName == ".jpg"|| extensionName == ".png")
                    {
                        photo.SaveAs(Server.MapPath("~/MemberPhotos/" + members.Account + extensionName));
                        members.MemberPhotoFile = members.Account + extensionName;                        
                    }
                }             
            }


            //var account = db.Members.Where(m => m.Account == members.Account).FirstOrDefault();
            //if (account != null)
            //{
            //    ViewBag.Error = "已經有相同帳號";
            //    return View();
            //}

            if (ModelState.IsValid)
            {
                
                db.Members.Add(members);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();      //***為甚麼沒有return View(members)，表單不會被清空
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);   //需要帶值至View，所以View頁面不能用VM
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Bind正向表列
        public ActionResult Edit(Members members)
        {
            //利用ADO.NET的寫法
            string sql = "update members set MemberName=@MemberName,MemberBirthday=@MemberBirthday where MemberID=@MemberID";
                       
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HW7ProjectConnection"].ConnectionString);  //裡面的參數是Web.config的連線資訊
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MemberName", members.MemberName);
            cmd.Parameters.AddWithValue("@MemberBirthday", members.MemberBirthday);
            cmd.Parameters.AddWithValue("@MemberID", members.MemberID);

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            conn.Close();

            return View(members);
            //if (ModelState.IsValid)
            //{
            //    db.Entry(members).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
