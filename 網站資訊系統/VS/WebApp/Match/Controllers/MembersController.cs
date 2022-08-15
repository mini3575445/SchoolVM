using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Match.Models;

namespace Match.Controllers
{
    [RightCheck]
    public class MembersController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Members
        public ActionResult Index()
        {
            var member = db.Member.Include(m => m.Right);
            return View(member.ToList());
        }

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
            return View(member);
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
        public ActionResult Create([Bind(Include = "member_id,member_account,member_password,member_name,member_id_name,member_gender,member_birthday,member_cellphone,member_email,member_address,right_id")] Member member)
        {
            //自動編號
            ChangeIDAuto changeIDAuto = new ChangeIDAuto();
            var last_data = db.Member.OrderByDescending(m => m.member_id).FirstOrDefault();     //抓資料庫Member最後一筆資料
            member.member_id = changeIDAuto.ChangeIDNumber(last_data.member_id, "P", 5);    //P00005

             //帳號不能相同，需將member資料轉為VMmember return ((尚未解決
            var account = db.Member.Where(m => m.member_account == member.member_account).FirstOrDefault();
            if (account != null)
            {
                ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
                ViewBag.ErrMsg = "此帳號已經註冊!";
                return View();  //View()回傳原本的狀態
            }

            if (ModelState.IsValid)
            {               
                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
            ViewBag.ErrMsg = "新增失敗";
            return View(member);
        }

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
            ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
            return View(member);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "member_id,member_account,member_password,member_name,member_id_name,member_gender,member_birthday,member_cellphone,member_email,member_address,right_id")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.right_id = new SelectList(db.Right, "right_id", "right_name", member.right_id);
            ViewBag.ErrMsg = "修改失敗";
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
