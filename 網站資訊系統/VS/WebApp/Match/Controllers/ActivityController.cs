using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Match.Models;
using Match.ViewModels;


namespace Match.Controllers
{
    public class ActivityController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Activity
        public ActionResult Index()
        {
            VMActivity vmactivity = new VMActivity()
            {
                activity = db.Activity.ToList(),
                activity_detail = db.Activity_detail.ToList()
            };   
            return View(vmactivity);
        }

        // GET: Activity/Details/5
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



        // GET: Activity/Edit/5
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
            ViewBag.state_id = new SelectList(db.State, "state_id", "state_name", activity.state_id);
            return View(activity);
        }

        // POST: Activity/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activity activity)
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
            ViewBag.state_id = new SelectList(db.State, "state_id", "state_name", activity.state_id);
            return View(activity);
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
