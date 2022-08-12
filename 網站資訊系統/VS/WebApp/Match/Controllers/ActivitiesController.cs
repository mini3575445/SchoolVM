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
    public class ActivitiesController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Activities
        public ActionResult Index()
        {
            var activity = db.Activity.Include(a => a.Activity_type).Include(a => a.Member).Include(a => a.Place);
            return View(activity.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.activity_type_id = new SelectList(db.Activity_type, "activity_type_id", "activity_type_name");
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account");
            ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id");
            return View();
        }

        // POST: Activities/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "activity_id,activity_type_id,activity_name,activity_datetime,place_id,member_id")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activity.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.activity_type_id = new SelectList(db.Activity_type, "activity_type_id", "activity_type_name", activity.activity_type_id);
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account", activity.member_id);
            ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id", activity.place_id);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.activity_type_id = new SelectList(db.Activity_type, "activity_type_id", "activity_type_name", activity.activity_type_id);
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account", activity.member_id);
            ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id", activity.place_id);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "activity_id,activity_type_id,activity_name,activity_datetime,place_id,member_id")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.activity_type_id = new SelectList(db.Activity_type, "activity_type_id", "activity_type_name", activity.activity_type_id);
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account", activity.member_id);
            ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id", activity.place_id);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Activity activity = db.Activity.Find(id);
            db.Activity.Remove(activity);
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
