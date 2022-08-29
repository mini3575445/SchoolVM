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
        
        public ActionResult Index(string activity_type_id = "C01")
        {

            //1.顯示index選擇的類別名稱
            ViewBag.strTypeID = activity_type_id;

            //將db資料帶入vm
            VMActivity vmactivity = new VMActivity()
            {
                activity = db.Activity.Where(a => a.activity_type_id == activity_type_id).ToList(),
                activity_detail = (from ad in db.Activity_detail
                                   join a in db.Activity on ad.activity_id equals a.activity_id
                                   where a.activity_type_id == activity_type_id
                                   select ad).ToList(),  
                activity_type = db.Activity_type.ToList()
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

        //給前台會員新增活動
        public ActionResult Create()
        {
            ViewBag.activity_type_id = new SelectList(db.Activity_type, "activity_type_id", "activity_type_name");
            ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account");
            ViewBag.place_id = new SelectList(db.Place, "place_id", "shop_name");
            ViewBag.state_id = new SelectList(db.State, "state_id", "state_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "activity_id,activity_type_id,activity_name,activity_datetime,place_id,member_id,activity_create_date,activity_join_deadline,activity_lower,activity_upper,state_id")] Activity activity)
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
            ViewBag.state_id = new SelectList(db.State, "state_id", "state_name", activity.state_id);
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

            VMActivity vmactivity = new VMActivity()
            {
                activity = db.Activity.Where(a => a.activity_id == id).ToList(),
                activity_detail = db.Activity_detail.Where(ad => ad.activity_id == id).ToList()
            };

            ViewBag.state = db.State.ToList();
            return View(vmactivity);
        }

        // POST: Activity/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activity activity)
        {
            //activity.Activity_type.activity_type_name = "A0002";
            ModelState.Remove("Activity_type.activity_type_name");
            ModelState.Remove("activity_type_name");
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.activity_type_id = new SelectList(db.Activity_type, "activity_type_id", "activity_type_name", activity.activity_type_id);
            //ViewBag.member_id = new SelectList(db.Member, "member_id", "member_account", activity.member_id);
            //ViewBag.place_id = new SelectList(db.Place, "place_id", "place_type_id", activity.place_id);
            //ViewBag.state_id = new SelectList(db.State, "state_id", "state_name", activity.state_id);
            return View();
        }


        //前台

        //前台無法看到已完成的活動
        //可透過縣市篩選
        //public ActionResult UserIndex(string activity_type_id="C01")
        //{

        //    //1.顯示index選擇的類別名稱
        //    //2.用於Create頁面的下拉式選單selected：將參數帶入View再傳至Create超連結
        //    ViewBag.strTypeID = activity_type_id;


        //    VMActivity vmactivity = new VMActivity()
        //    {
        //        activity = db.Activity.Where(a => a.activity_type_id == activity_type_id).ToList(),
        //        activity_detail = (from ad in db.Activity_detail
        //                           join a in db.Activity on ad.activity_id equals a.activity_id
        //                           where a.activity_type_id == activity_type_id
        //                           select ad).ToList(),
        //        activity_type = db.Activity_type.ToList()
        //    };
        //    return View(vmactivity);
        //}
        public ActionResult UserIndex(string activity_type_id="C01",string place_address="全部")
        {

            //1.顯示index選擇的類別名稱
            //2.用於Create頁面的下拉式選單selected：將參數帶入View再傳至Create超連結
            ViewBag.strTypeID = activity_type_id;
            VMActivity vmactivity = new VMActivity()
            {
                activity_type = db.Activity_type.ToList()
            };


            if (place_address == "全部")
            {
                vmactivity.activity = db.Activity.Where(a => a.activity_type_id == activity_type_id).ToList();

                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where a.activity_type_id == activity_type_id
                                              select ad).ToList();             
            }
            else    //篩選縣市
            {
                
                vmactivity.activity = (from a in db.Activity
                                        join p in db.Place on a.place_id equals p.place_id
                                        where p.place_address.StartsWith(place_address) && a.activity_type_id == activity_type_id
                                        select a).ToList();

                vmactivity.activity_detail = (from ad in db.Activity_detail
                                                join a in db.Activity on ad.activity_id equals a.activity_id
                                                join p in db.Place on a.place_id equals p.place_id
                                                where p.place_address.StartsWith(place_address) && a.activity_type_id == activity_type_id
                                                select ad).ToList();
            }           
            
            return View(vmactivity);
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
