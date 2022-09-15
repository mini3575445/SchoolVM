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

    [LoginCheck]
    public class FriendController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Friend
        public ActionResult Index()
        {
            //     member1   member2
            //1     A會員     B會員
            //2     B會員     A會員
            //3     C會員     D會員

            //一、成為好友：A、B
            //二、送出好友邀請：C
            //三、是否接受好友邀請：D


            
            string SessionID = Session["member_id"].ToString();

            VMFriend vmfriend = new VMFriend();
            vmfriend.wait = db.Friend.Where(f => f.friend_member1 == SessionID).ToList();
            vmfriend.invite = db.Friend.Where(f => f.friend_member2 == SessionID).ToList();

            //找match
            vmfriend.match = new List<Friend>();
            foreach (var item in vmfriend.wait) 
            {
                Friend result = vmfriend.invite.Find(fi => fi.friend_member1 == item.friend_member2);
                if (result != null) 
                {
                    vmfriend.match.Add(result);
                }                  
            }

            //移除wait、invite中的Match
            foreach (var item in vmfriend.match) 
            {
                Friend waitResult = vmfriend.wait.Find(fw => fw.friend_member2 == item.friend_member1);
                if (waitResult != null)
                {
                    vmfriend.wait.Remove(waitResult);
                }
                Friend inviteResult = vmfriend.invite.Find(fi => fi.friend_member1 == item.friend_member1);
                if (inviteResult != null)
                {
                    vmfriend.invite.Remove(inviteResult);
                }
            }

            //wait的會員
            vmfriend.waitMember = new List<Member>();
            foreach (var item in vmfriend.wait)
            {
                Member waitMemberResult = db.Member.Where(m => m.member_id == item.friend_member2).FirstOrDefault();
                if (waitMemberResult != null)
                {
                    vmfriend.waitMember.Add(waitMemberResult);
                }
            }
            return View(vmfriend);
        }



        // GET: Friend/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friend.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {            
            return PartialView();
        }

        // POST: Friends/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string member_name)
        {
            var result = db.Member.Where(m => m.member_name == member_name).FirstOrDefault();
            if (result == null) 
            {
                ViewBag.ErrMsg = "找不到此名稱";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = new Friend();
            //流水號
            var last_data = db.Friend.OrderByDescending(f => f.friend_number).FirstOrDefault();
            friend.friend_number = last_data.friend_number + 1;

            //登入者ID
            string SessionID = Session["member_id"].ToString();
            friend.friend_member1 = SessionID;

            //輸入會員名稱的ID
            friend.friend_member2 = result.member_id;

            //建立時間
            friend.friend_create_date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Friend.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        //只有對方送邀請才能走這支
        public ActionResult ConfirmFriend(string id)
        {
            //登入者的邀請是否有id
            string SessionID = Session["member_id"].ToString();
            Friend result = db.Friend.Where(f => f.friend_member1 ==id && f.friend_member2 == SessionID).FirstOrDefault();

            if (result == null) //沒有此ID
            {
                return RedirectToAction("Index");
            }
            Friend friend = new Friend();
            //流水號
            var last_data = db.Friend.OrderByDescending(f => f.friend_number).FirstOrDefault();
            friend.friend_number = last_data.friend_number + 1;

            //登入者ID
            friend.friend_member1 = SessionID;

            //輸入會員名稱的ID
            friend.friend_member2 = result.friend_member1;

            //建立時間
            friend.friend_create_date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Friend.Add(friend);
                db.SaveChanges();                
            }
            return RedirectToAction("Index");
        }





        // GET: Friends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friend.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            ViewBag.friend_member1 = new SelectList(db.Member, "member_id", "member_account", friend.friend_member1);
            ViewBag.friend_member2 = new SelectList(db.Member, "member_id", "member_account", friend.friend_member2);
            return View(friend);
        }

        // POST: Friends/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "friend_number,friend_member1,friend_member2,friend_create_date")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.friend_member1 = new SelectList(db.Member, "member_id", "member_account", friend.friend_member1);
            ViewBag.friend_member2 = new SelectList(db.Member, "member_id", "member_account", friend.friend_member2);
            return View(friend);
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friend.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            //只有接收方與送出方能刪除
            string SessionID = Session["member_id"].ToString();
            if (SessionID == friend.friend_member1 || SessionID == friend.friend_member2)
            {
                db.Friend.Remove(friend);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //// POST: Friends/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Friend friend = db.Friend.Find(id);

        //    //只有接收方與送出方能刪除
        //    string SessionID = Session["member_id"].ToString();
        //    if (SessionID == friend.friend_member1 || SessionID == friend.friend_member2)
        //    {
        //        db.Friend.Remove(friend);
        //        db.SaveChanges();
        //    }            
        //    return RedirectToAction("Index");
        //}

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
