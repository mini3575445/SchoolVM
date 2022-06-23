using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _00Northwind.Models;

namespace _00Northwind.Controllers
{
    public class 員工Controller : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: 員工
        public ActionResult Index()
        {
            return View(db.員工.ToList());
        }

        // GET: 員工/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            員工 員工 = db.員工.Find(id);
            if (員工 == null)
            {
                return HttpNotFound();
            }
            return View(員工);
        }

        // GET: 員工/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 員工/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "員工編號,姓名,名,職稱,稱呼,出生日期,雇用日期,地址,城市,行政區,區域號碼,國家地區,電話號碼,內部分機號碼,相片,附註,主管")] 員工 員工)
        {
            if (ModelState.IsValid)
            {
                db.員工.Add(員工);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(員工);
        }

        // GET: 員工/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            員工 員工 = db.員工.Find(id);
            if (員工 == null)
            {
                return HttpNotFound();
            }
            return View(員工);
        }

        // POST: 員工/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "員工編號,姓名,名,職稱,稱呼,出生日期,雇用日期,地址,城市,行政區,區域號碼,國家地區,電話號碼,內部分機號碼,相片,附註,主管")] 員工 員工)
        {
            if (ModelState.IsValid)
            {
                db.Entry(員工).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(員工);
        }

        // GET: 員工/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            員工 員工 = db.員工.Find(id);
            if (員工 == null)
            {
                return HttpNotFound();
            }
            return View(員工);
        }

        // POST: 員工/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            員工 員工 = db.員工.Find(id);
            db.員工.Remove(員工);
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
