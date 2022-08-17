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
    public class PlaceController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Place
        public ActionResult Index()
        {
            var place = db.Place.Include(p => p.Place_type);
            return View(place.ToList());
        }

        // GET: Place/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Place.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Place/Create
        public ActionResult Create()
        {
            ViewBag.place_type_id = new SelectList(db.Place_type, "place_type_id", "place_type_name");
            return View();
        }

        // POST: Place/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "place_id,place_type_id,shop_name,place_address,place_phone,place_hours_start,place_hours_end,place_create_date")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Place.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.place_type_id = new SelectList(db.Place_type, "place_type_id", "place_type_name", place.place_type_id);
            return View(place);
        }

        // GET: Place/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Place.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.place_type_id = new SelectList(db.Place_type, "place_type_id", "place_type_name", place.place_type_id);
            return View(place);
        }

        // POST: Place/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "place_id,place_type_id,shop_name,place_address,place_phone,place_hours_start,place_hours_end,place_create_date")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.place_type_id = new SelectList(db.Place_type, "place_type_id", "place_type_name", place.place_type_id);
            return View(place);
        }

        // GET: Place/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Place.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Place/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Place place = db.Place.Find(id);
            db.Place.Remove(place);
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
