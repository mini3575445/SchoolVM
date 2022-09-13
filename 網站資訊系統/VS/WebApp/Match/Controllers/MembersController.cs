using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Match.Models;
using PagedList;

namespace Match.Controllers
{    
    public class MembersController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Members
        [RightCheck]
        public ActionResult Index(int page=1)
        {
            List<Member> member = db.Member.Include(m => m.Right).ToList();

            int pagesize = 5;
            var pagedList = member.ToPagedList(page, pagesize);
            return View(pagedList);
        }

        [RightCheck]
        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return PartialView(member);
        }


        // GET: Members/Create
        public ActionResult Create()
        {
            
            ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name");  //傳入權限資料用於下拉式選單
            return View();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member, HttpPostedFileBase photo)
        {
            //照片上傳
            if (photo != null) 
            {
                if (photo.ContentLength>0)   //上傳檔案大小
                { 
                    string extensionName = System.IO.Path.GetExtension(photo.FileName); //抓副檔名
                    if (extensionName == ".jpg" || extensionName == ".png")
                    {
                        photo.SaveAs(Server.MapPath("~/MemberPhotos/" + member.member_account + extensionName));    //會員帳號為照片檔名
                        member.member_photo_file = member.member_account + extensionName;
                    }
                }
            }           

            //自動編號
            ChangeIDAuto changeIDAuto = new ChangeIDAuto();
            var last_data = db.Member.OrderByDescending(m => m.member_id).FirstOrDefault();     //抓資料庫Member最後一筆資料
            member.member_id = changeIDAuto.ChangeIDNumber(last_data.member_id, "P", 5);    //P00005

            //建立日期
            member.member_create_date = DateTime.Now;


            //***商業邏輯寫在Model比較好
            //帳號不能相同，需將member資料轉為VMmember return 
            //var account = db.Member.Where(m => m.member_account == member.member_account).FirstOrDefault();
            //if (account != null)
            //{
            //    ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
            //    ViewBag.ErrMsg = "此帳號已經註冊!";
            //    return View();  //View()回傳原本的狀態
            //}

            if (ModelState.IsValid)
            {               
                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
            //ViewBag.ErrMsg = "照片檔案類型必須為jpg或png";
            return View();
        }

        [RightCheck]
        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            //檢查登入者權限>被修改會員
            const string rank = "ABCDE";
            int userRight = rank.IndexOf(Session["right"].ToString());
            int memberRight = rank.IndexOf(member.right_id.ToString());            
            if (userRight>memberRight)  //權限越高，數值越小
            {
                return HttpNotFound();
            }


            ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
            return View(member);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [RightCheck]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member member, HttpPostedFileBase photo)
        {
            //照片上傳
            if (photo != null)
            {
                if (photo.ContentLength > 0)   //上傳檔案大小
                {
                    string extensionName = System.IO.Path.GetExtension(photo.FileName); //抓副檔名
                    if (extensionName == ".jpg" || extensionName == ".png")
                    {
                        photo.SaveAs(Server.MapPath("~/MemberPhotos/" + member.member_account + extensionName));    //會員帳號為照片檔名
                        member.member_photo_file = member.member_account + extensionName;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
            ViewBag.ErrMsg = "照片檔案類型必須為jpg或png";
            return View(member);
        }

        //GET: Members/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Member member = db.Member.Find(id);
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
        //}

        //POST: Members/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Member member = db.Member.Find(id);
        //    db.Member.Remove(member);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
