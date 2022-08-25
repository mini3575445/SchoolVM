using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7Project.Models;

namespace HW7Project.Controllers
{
    public class ProductsController : Controller
    {
        private HW7ProjectContext db = new HW7ProjectContext();
        
        
        
        // GET: Products
        public ActionResult Index()
        {            
            return View(db.Products.ToList());
        }

        [LogReporter(recordFlag = false)]
        //取得圖片
        public FileContentResult GetImage(string id)    //***FileContentResult回傳結果為檔案，並不是路徑
        {
            var photo = db.Products.Find(id);
            if (photo == null)
            { 
                return null;
            }
            return File(photo.PhotoFile, photo.ImageMimeType);
        }


        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Products/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products, HttpPostedFileBase photo)
        {   
            //照片不能空
            if (photo == null)
            { 
                ViewBag.ErrMessage = "請上傳商品照片";
                return View(products);
            }
            //商品編號不重複
            if (db.Products.Find(products.ProductID) != null)
            {
                ViewBag.ErrMessage2 = "商品編號重複";
                return View(products);
            }

            products.ImageMimeType = photo.ContentType; //抓副檔名

            //照片檔案處理
            products.PhotoFile = new byte[photo.ContentLength];
            photo.InputStream.Read(products.PhotoFile, 0, photo.ContentLength);
                                    //(byte[]檔案 ,從0開始,到結束)                       

            products.CreatedDate = DateTime.Today;
            products.Discontinued = false;

            ModelState.Remove("PhotoFile");  //***移除驗證(不要驗證這個欄位)

            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products, HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                products.ImageMimeType = photo.ContentType;

                products.PhotoFile = new byte[photo.ContentLength];
                photo.InputStream.Read(products.PhotoFile, 0, photo.ContentLength);
            }

            ModelState.Remove("PhotoFile");
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult ProductStatusChange(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            products.Discontinued = !products.Discontinued;
            db.Entry(products).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
