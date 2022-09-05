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
    public class UserActivityController : Controller
    {
        private MatchEntities db = new MatchEntities();

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



        


        public ActionResult Index(string activity_type_id="所有類別",string place_address="所有縣市")
        {
            //活動可分為三種類型:
            //一、不顯示於前台:1.已完成 or 2.活動時間到期
            //二、顯示但不可加入:1.停止報名 or 2.報名截止日到期 or 3.人數已滿
            //三、顯示且可加入:1.報名中 and 2.活動時間未到期 and 3.報名截止未到期 and 4.人數未滿

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
                activity = db.Activity.Where(a=>a.state_id!=3 && a.activity_datetime>DateTime.Now).ToList(),
                activity_detail = (from ad in db.Activity_detail
                                   join a in db.Activity on ad.activity_id equals a.activity_id
                                   join p in db.Place on a.place_id equals p.place_id
                                   where a.state_id != 3 && a.activity_datetime > DateTime.Now
                                   select ad).ToList()
            };

            if (activity_type_id != "所有類別" && place_address == "所有縣市")   //二、activity_type_id="C01"；place_address="所有縣市"
            {
                vmactivity.activity = db.Activity.Where(a => a.state_id != 3 && a.activity_datetime > DateTime.Now 
                                                        && a.activity_type_id == activity_type_id).ToList();
                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where a.state_id != 3 && a.activity_datetime > DateTime.Now 
                                                    && a.activity_type_id == activity_type_id
                                              select ad).ToList();
            }
            else if (activity_type_id == "所有類別" && place_address != "所有縣市")     //三、activity_type_id="所有類別"；place_address="高雄"
            {
                vmactivity.activity = (from a in db.Activity
                                       join p in db.Place on a.place_id equals p.place_id
                                       where a.state_id != 3 && a.activity_datetime > DateTime.Now
                                            && p.place_address.StartsWith(place_address)
                                       select a).ToList();
                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where a.state_id != 3 && a.activity_datetime > DateTime.Now 
                                                    && p.place_address.StartsWith(place_address)
                                              select ad).ToList();
            }
            else if(activity_type_id != "所有類別" && place_address != "所有縣市")   //四、activity_type_id="C01"；place_address="高雄"
            {
                vmactivity.activity = (from a in db.Activity
                                       join p in db.Place on a.place_id equals p.place_id
                                       where a.state_id != 3 && a.activity_datetime > DateTime.Now 
                                            && p.place_address.StartsWith(place_address) && a.activity_type_id == activity_type_id
                                       select a).ToList();
                vmactivity.activity_detail = (from ad in db.Activity_detail
                                              join a in db.Activity on ad.activity_id equals a.activity_id
                                              join p in db.Place on a.place_id equals p.place_id
                                              where a.state_id != 3 && a.activity_datetime > DateTime.Now 
                                                    && p.place_address.StartsWith(place_address) && a.activity_type_id == activity_type_id
                                              select ad).ToList();
            }                     
            return View(vmactivity);
        }

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


        //User加入活動
        public ActionResult JoinActivity(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //1.找的到activityID
            //2.狀態為1
            //3.活動截止時間>目前時間
            //4.加入後不大於最多人數
            //5.加入的活動中沒重複的MemberID

            Activity activity = db.Activity.Find(id);
            //1.找的到activityID
            if (activity == null)
            {
                return HttpNotFound();
            }

            string sesstion_memberID = Session["member_id"].ToString();

            //4.加入後不大於最多人數
            int peopleCount = db.Activity_detail.Where(ad => ad.activity_id == id).Count();

            //5.加入的活動中沒重複的MemberID
            Activity_detail checkMember = db.Activity_detail.Where(ad => ad.activity_id == id && ad.member_id == sesstion_memberID).FirstOrDefault();
            
            //2~5
            if (activity.state_id != 1 || activity.activity_join_deadline < DateTime.Now || activity.activity_upper < peopleCount+1 || checkMember != null) 
            {
                return HttpNotFound();
            }

            Activity_detail activity_detail = new Activity_detail()
            {
                activity_id = activity.activity_id,
                member_id = sesstion_memberID,
                join_date = DateTime.Now
            };

            //流水號
            var last_data = db.Activity_detail.OrderByDescending(ad => ad.activity_detail_number).FirstOrDefault();
            activity_detail.activity_detail_number = last_data.activity_detail_number + 1;

            if (ModelState.IsValid)
            {
                db.Activity_detail.Add(activity_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
