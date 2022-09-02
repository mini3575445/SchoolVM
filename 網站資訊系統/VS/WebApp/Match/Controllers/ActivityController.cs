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
        public ActionResult Index(string activity_type_id = "所有類別", string place_address = "所有縣市")
        {
            //1.顯示index選擇的類別名稱
            //2.用於Create頁面的下拉式選單selected：將參數帶入View再傳至Create超連結
            ViewBag.strTypeID = activity_type_id;
            ViewBag.city = place_address;

            //參數篩選條件不同(無法where="所有縣市")，可分為四種情形:
            //一、預設：activity_type_id="所有類別"；place_address="所有縣市"
            //二、activity_type_id="C01"；place_address="所有縣市"
            //三、activity_type_id="所有類別"；place_address="高雄"
            //四、activity_type_id="C01"；place_address="高雄"

            VMActivity vmactivity = new VMActivity()    //一、預設：activity_type_id="所有類別"；place_address="所有縣市"
            {
                activity_type = db.Activity_type.ToList(),
                activity = db.Activity.ToList(),
                activity_detail = db.Activity_detail.ToList()
            };

            if (activity_type_id != "所有類別" && place_address == "所有縣市")   //二、activity_type_id="C01"；place_address="所有縣市"
            {
                vmactivity.activity = db.Activity.Where(a => a.activity_type_id == activity_type_id).ToList();
                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where a.activity_type_id == activity_type_id
                                              select ad).ToList();
            }
            else if (activity_type_id == "所有類別" && place_address != "所有縣市")     //三、activity_type_id="所有類別"；place_address="高雄"
            {
                vmactivity.activity = (from a in db.Activity
                                       join p in db.Place on a.place_id equals p.place_id
                                       where p.place_address.StartsWith(place_address)
                                       select a).ToList();
                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where p.place_address.StartsWith(place_address)
                                              select ad).ToList();
            }
            else if (activity_type_id != "所有類別" && place_address != "所有縣市")   //四、activity_type_id="C01"；place_address="高雄"
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


        //public ActionResult Index(string activity_type_id = "C01")
        //{

        //    //1.顯示index選擇的類別名稱
        //    ViewBag.strTypeID = activity_type_id;

        //    //將db資料帶入vm
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


        // GET: Activity/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Activity activity = db.Activity.Find(id);
            //activity.Place = (from p in db.Place
            //                  join a in db.Activity on p.place_id equals a.place_id
            //                  where a.activity_id == id
            //                  select p).FirstOrDefault();

            if (activity == null)
            {
                return HttpNotFound();
            }
            
            return View(activity);



            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //Activity activity = db.Activity.Find(id);
            //if (activity == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(activity);
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
        public ActionResult Create(Activity activity)
        {
            //檢查活動地點是否為停業狀態
            //List<Place> place = db.Place.Where(p => p.place_id == activity.place_id).ToList();
            //var checkShutdown = place[0].place_shutdown;
            //if (checkShutdown) //ture為停業狀態
            //{ 
            //    ViewBag.ErrMsg = "地點已停業，請選擇其他地點";
            //    return View(activity);
            //}

            //自動編號
            ChangeIDAuto changeIDAuto = new ChangeIDAuto();
            var last_data = db.Activity.OrderByDescending(m => m.activity_id).FirstOrDefault();     //抓資料庫最後一筆資料
            activity.activity_id = changeIDAuto.ChangeIDNumber(last_data.activity_id, "A", 5);    //A00005

            //建立日期
            activity.activity_create_date = DateTime.Now;

            //member_id為登入者(寫在create:hidden)
            //activity.member_id = Session["member_id"].ToString();

            //報名狀態預設為報名中
            activity.state_id = 1;

            if (ModelState.IsValid)
            {
                //新增成功再將資料寫入Activity_detail

                var lastNum = db.Activity_detail.OrderByDescending(ad => ad.activity_detail_number).FirstOrDefault().activity_detail_number;
                Activity_detail activity_detail = new Activity_detail()
                {                    
                    activity_detail_number = lastNum+1,
                    activity_id = activity.activity_id,
                    member_id = activity.member_id,
                    join_date = activity.activity_create_date
                };
                activity.Activity_detail.Add(activity_detail);

                //ICollection<Activity_detail> list2 = new List<Activity_detail>();
                //list2.Add(db.Activity_detail.FirstOrDefault());

                //List<Activity_detail> activity_detail = new List<Activity_detail>();

                //Activity_detail activity_detail = new Activity_detail()
                //{
                //    activity_detail_number = db.Activity_detail.OrderByDescending(ad => ad.activity_detail_number).FirstOrDefault().activity_detail_number,
                //    activity_id = activity.activity_id,
                //    member_id = activity.member_id,
                //    join_date = activity.activity_create_date
                //};

                //db.Activity_detail.Add(activity.Activity_detail);
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
        public ActionResult UserIndex(string activity_type_id="所有類別",string place_address="所有縣市")
        {
            //1.顯示index選擇的類別名稱
            //2.用於Create頁面的下拉式選單selected：將參數帶入View再傳至Create超連結
            ViewBag.strTypeID = activity_type_id;
            ViewBag.city = place_address;

            //參數篩選條件不同(無法where="所有縣市")，可分為四種情形:
            //一、預設：activity_type_id="所有類別"；place_address="所有縣市"
            //二、activity_type_id="C01"；place_address="所有縣市"
            //三、activity_type_id="所有類別"；place_address="高雄"
            //四、activity_type_id="C01"；place_address="高雄"

            VMActivity vmactivity = new VMActivity()    //一、預設：activity_type_id="所有類別"；place_address="所有縣市"
            {
                activity_type = db.Activity_type.ToList(),
                activity = db.Activity.ToList(),
                activity_detail = db.Activity_detail.ToList()
            };

            if (activity_type_id != "所有類別" && place_address == "所有縣市")   //二、activity_type_id="C01"；place_address="所有縣市"
            {
                vmactivity.activity = db.Activity.Where(a => a.activity_type_id == activity_type_id).ToList();
                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where a.activity_type_id == activity_type_id
                                              select ad).ToList();
            }
            else if (activity_type_id == "所有類別" && place_address != "所有縣市")     //三、activity_type_id="所有類別"；place_address="高雄"
            {
                vmactivity.activity = (from a in db.Activity
                                       join p in db.Place on a.place_id equals p.place_id
                                       where p.place_address.StartsWith(place_address)
                                       select a).ToList();
                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where p.place_address.StartsWith(place_address)
                                              select ad).ToList();
            }
            else if(activity_type_id != "所有類別" && place_address != "所有縣市")   //四、activity_type_id="C01"；place_address="高雄"
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
