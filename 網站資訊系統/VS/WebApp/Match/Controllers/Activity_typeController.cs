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
    public class Activity_typeController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Activity_type
        public ActionResult Index()
        {
            return View(db.Activity_type.ToList());
        }

        // GET: Activity_type/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_type activity_type = db.Activity_type.Find(id);
            if (activity_type == null)
            {
                return HttpNotFound();
            }
            return View(activity_type);
        }

        // GET: Activity_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity_type/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "activity_type_id,activity_type_name")] Activity_type activity_type)
        {
            //自動編號
            ChangeIDAuto changeIDAuto = new ChangeIDAuto();
            var last_data = db.Activity_type.OrderByDescending(at => at.activity_type_id).FirstOrDefault();     
            activity_type.activity_type_id = changeIDAuto.ChangeIDNumber(last_data.activity_type_id, "C", 2);    //C05

            if (ModelState.IsValid)
            {
                db.Activity_type.Add(activity_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity_type);
        }

        // GET: Activity_type/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_type activity_type = db.Activity_type.Find(id);
            if (activity_type == null)
            {
                return HttpNotFound();
            }
            return View(activity_type);
        }

        // POST: Activity_type/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "activity_type_id,activity_type_name")] Activity_type activity_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity_type);
        }

        // GET: Activity_type/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_type activity_type = db.Activity_type.Find(id);
            if (activity_type == null)
            {
                return HttpNotFound();
            }
            return View(activity_type);
        }

        // POST: Activity_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Activity_type activity_type = db.Activity_type.Find(id);
            db.Activity_type.Remove(activity_type);
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
