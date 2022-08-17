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
    public class Place_off_dayController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Place_off_day
        public ActionResult Index()
        {
            var place_off_day = db.Place_off_day.Include(p => p.Place);
            return View(place_off_day.ToList());
        }

        // GET: Place_off_day/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place_off_day place_off_day = db.Place_off_day.Find(id);
            if (place_off_day == null)
            {
                return HttpNotFound();
            }
            return View(place_off_day);
        }

        // GET: Place_off_day/Create
        public ActionResult Create()
        {
            ViewBag.table_place = db.Place.ToList();
            //ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id");   
            return View();
        }

        // POST: Place_off_day/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "place_off_day_number,place_id,place_off_day1")] Place_off_day place_off_day)
        {
            //流水號
            var last_data = db.Place_off_day.OrderByDescending(pod => pod.place_off_day_number).FirstOrDefault();
            place_off_day.place_off_day_number = last_data.place_off_day_number + 1;

            if (ModelState.IsValid)
            {
                db.Place_off_day.Add(place_off_day);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id", place_off_day.place_id);
            return View(place_off_day);
        }

        // GET: Place_off_day/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place_off_day place_off_day = db.Place_off_day.Find(id);
            if (place_off_day == null)
            {
                return HttpNotFound();
            }
            ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id", place_off_day.place_id);
            return View(place_off_day);
        }

        // POST: Place_off_day/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "place_off_day_number,place_id,place_off_day1")] Place_off_day place_off_day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place_off_day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id", place_off_day.place_id);
            return View(place_off_day);
        }

        // GET: Place_off_day/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place_off_day place_off_day = db.Place_off_day.Find(id);
            if (place_off_day == null)
            {
                return HttpNotFound();
            }
            return View(place_off_day);
        }

        // POST: Place_off_day/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place_off_day place_off_day = db.Place_off_day.Find(id);
            db.Place_off_day.Remove(place_off_day);
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
