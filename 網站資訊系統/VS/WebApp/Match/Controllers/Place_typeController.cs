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
    public class Place_typeController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Place_type
        public ActionResult Index()
        {
            return View(db.Place_type.ToList());
        }
                

        // GET: Place_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Place_type/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "place_type_id,place_type_name")] Place_type place_type)
        {
            //自動編號
            ChangeIDAuto changeIDAuto = new ChangeIDAuto();
            var last_data = db.Place_type.OrderByDescending(pt => pt.place_type_id).FirstOrDefault();
            place_type.place_type_id = changeIDAuto.ChangeIDNumber(last_data.place_type_id, "E", 2);    //E05

            if (ModelState.IsValid)
            {
                db.Place_type.Add(place_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place_type);
        }

        // GET: Place_type/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place_type place_type = db.Place_type.Find(id);
            if (place_type == null)
            {
                return HttpNotFound();
            }
            return View(place_type);
        }

        // POST: Place_type/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "place_type_id,place_type_name")] Place_type place_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place_type);
        }

        // GET: Place_type/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place_type place_type = db.Place_type.Find(id);
            if (place_type == null)
            {
                return HttpNotFound();
            }
            return View(place_type);
        }

        // POST: Place_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Place_type place_type = db.Place_type.Find(id);
            db.Place_type.Remove(place_type);
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
