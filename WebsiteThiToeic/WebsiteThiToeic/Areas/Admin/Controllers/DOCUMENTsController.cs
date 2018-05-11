using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteThiToeic.Access.EF;

namespace WebsiteThiToeic.Areas.Admin.Controllers
{
    public class DOCUMENTsController : Controller
    {
        private Db db = new Db();

        // Upload: Admin/DOCUMENTs/
        //[HttpPost]
        //public ActionResult Upload(FormCollection form, DOCUMENT dOCUMENT)
        //{
        //    var loaifile = int.Parse(form.Get("loaifile"));
        //    var f = Request.Files[0];
        //    if (f != null)
        //    {
        //        var fileName = Path.GetFileName(f.FileName);
        //        var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
        //        f.SaveAs(path);


        //        dOCUMENT.URL =  Path.GetFileName(f.FileName);
        //        dOCUMENT.NAME = fileName;
        //        dOCUMENT.TYPE = loaifile;
        //        db.DOCUMENTs.Add(dOCUMENT);
        //        db.SaveChanges();

        //    }
        //    return RedirectToAction("Index");
        //}

        // GET: Admin/DOCUMENTs
        public ActionResult Index()
        {
            return View(db.DOCUMENTs.ToList());
        }

        // GET: Admin/DOCUMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // GET: Admin/DOCUMENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DOCUMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,URL,TYPE")] DOCUMENT dOCUMENT)
        {
            if (ModelState.IsValid)
            {
                db.DOCUMENTs.Add(dOCUMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOCUMENT);
        }

        // GET: Admin/DOCUMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // POST: Admin/DOCUMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,URL,TYPE")] DOCUMENT dOCUMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOCUMENT);
        }

        // GET: Admin/DOCUMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // POST: Admin/DOCUMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            db.DOCUMENTs.Remove(dOCUMENT);
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
