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
    public class PlaceController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Place
        public ActionResult Index(string place_type_id="E01")
        {

            //1.顯示index選擇的類別名稱
            //2.用於Create頁面的下拉式選單selected：將參數帶入View再傳至Create超連結
            ViewBag.strTypeID = place_type_id;

            //將db資料帶入vm
            VMPlace vmplace = new VMPlace(){                
                place = db.Place.Where(p=>p.place_type_id == place_type_id).ToList(),
                place_off_day = (from pod in db.Place_off_day
                                 join p in db.Place on pod.place_id equals p.place_id
                                 where p.place_type_id == place_type_id
                                 orderby pod.place_id,pod.place_off_day1
                                 select pod).ToList(),  //選出參數類別的公休日
                place_type = db.Place_type.ToList()
            };
            return View(vmplace);
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
        public ActionResult Create(Place place)
        {            
            //自動編號
            ChangeIDAuto changeIDAuto = new ChangeIDAuto();
            var last_data = db.Place.OrderByDescending(p => p.place_id).FirstOrDefault();
            place.place_id = changeIDAuto.ChangeIDNumber(last_data.place_id, "S", 5);    //S00005
            
            //建立日期
            place.place_create_date = DateTime.Now;

            //找驗證錯誤
            //if (!ModelState.IsValid)
            //{
            //    var msg = string.Empty;
            //    foreach (var value in ModelState.Values)
            //    {
            //        if (value.Errors.Count > 0)
            //        {
            //            foreach (var error in value.Errors)
            //            { 
            //                msg = msg + error.ErrorMessage;
            //            }
            //        }
            //    }
            //}
                       
            var result = (from pt in db.Place_type
                          join p in db.Place on pt.place_type_id equals p.place_type_id
                          where pt.place_type_id == place.place_type_id && p.shop_name == place.shop_name
                          select pt).ToList();  //檢查同類別中不能有相同名稱
            if (result.Count != 0) 
            {
                ViewBag.ErrMsg = "同樣類型中不可有相同地點名稱";
                ViewBag.place_type_id = new SelectList(db.Place_type, "place_type_id", "place_type_name", place.place_type_id);
                return View(place);
            }

                if (ModelState.IsValid)
                {
                db.Place.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index", new { place_type_id=place.place_type_id});    //完成新增後，到新增的類別
                }

            ViewBag.ErrMsg = "新增失敗";
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
                return RedirectToAction("Index", new { place_type_id = place.place_type_id });
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
