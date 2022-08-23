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
    public class Activity_detailController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Activity_detail
        public ActionResult Index()
        {
            var activity_detail = db.Activity_detail.Include(a => a.Activity).Include(a => a.Member);
            return View(activity_detail.ToList());
        }

        // GET: Activity_detail/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_detail activity_detail = db.Activity_detail.Find(id);
            if (activity_detail == null)
            {
                return HttpNotFound();
            }
            return View(activity_detail);
        }

        // GET: Activity_detail/Create
        public ActionResult Create()
        {
            ViewBag.activity_id = new SelectList(db.Activity, "activity_id", "activity_type_id");
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account");
            return View();
        }

        // POST: Activity_detail/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "activity_detail_number,activity_id,member_id")] Activity_detail activity_detail)
        {
            if (ModelState.IsValid)
            {
                db.Activity_detail.Add(activity_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.activity_id = new SelectList(db.Activity, "activity_id", "activity_type_id", activity_detail.activity_id);
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account", activity_detail.member_id);
            return View(activity_detail);
        }

        // GET: Activity_detail/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_detail activity_detail = db.Activity_detail.Find(id);
            if (activity_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.activity_id = new SelectList(db.Activity, "activity_id", "activity_type_id", activity_detail.activity_id);
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account", activity_detail.member_id);
            return View(activity_detail);
        }

        // POST: Activity_detail/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "activity_detail_number,activity_id,member_id")] Activity_detail activity_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.activity_id = new SelectList(db.Activity, "activity_id", "activity_type_id", activity_detail.activity_id);
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account", activity_detail.member_id);
            return View(activity_detail);
        }

        // GET: Activity_detail/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_detail activity_detail = db.Activity_detail.Find(id);
            if (activity_detail == null)
            {
                return HttpNotFound();
            }
            return View(activity_detail);
        }

        // POST: Activity_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Activity_detail activity_detail = db.Activity_detail.Find(id);
            db.Activity_detail.Remove(activity_detail);
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
