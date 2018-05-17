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
    public class LISTENNINGsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/LISTENNINGs
        public ActionResult Index()
        {
            var lISTENNINGs = db.LISTENNINGs.Include(l => l.PART);
            return View(lISTENNINGs.ToList());
        }

        // GET: Admin/LISTENNINGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTENNING lISTENNING = db.LISTENNINGs.Find(id);
            if (lISTENNING == null)
            {
                return HttpNotFound();
            }
            return View(lISTENNING);
        }

        // GET: Admin/LISTENNINGs/Create
        public ActionResult Create()
        {
            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT");
            return View();
        }

        // POST: Admin/LISTENNINGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PAR_ID,LISTEN_URL,NAME,PICTURE_URL,CORRECT_ANSWER,LEVEL,TYPE")] LISTENNING lISTENNING)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files[0];
                var fimage = Request.Files[1];
                string fileName = string.Empty;
                string IfileName = string.Empty;
                
                if (f != null)
                {
                    fileName = Path.GetFileName(f.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    f.SaveAs(path);
                }
                if (fimage != null)
                {
                    IfileName = Path.GetFileName(fimage.FileName);
                    var ipath = Path.Combine(Server.MapPath("~/Uploads/Image"), IfileName);
                    fimage.SaveAs(ipath);
                }

                lISTENNING.LISTEN_URL = fileName ;
                lISTENNING.PICTURE_URL = IfileName;
                db.LISTENNINGs.Add(lISTENNING);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT", lISTENNING.PAR_ID);
            return View(lISTENNING);
        }

        // GET: Admin/LISTENNINGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTENNING lISTENNING = db.LISTENNINGs.Find(id);
            if (lISTENNING == null)
            {
                return HttpNotFound();
            }
            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT", lISTENNING.PAR_ID);
            return View(lISTENNING);
        }

        // POST: Admin/LISTENNINGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PAR_ID,LISTEN_URL,NAME,PICTURE_URL,CORRECT_ANSWER,LEVEL,TYPE")] LISTENNING lISTENNING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lISTENNING).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT", lISTENNING.PAR_ID);
            return View(lISTENNING);
        }

        // GET: Admin/LISTENNINGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTENNING lISTENNING = db.LISTENNINGs.Find(id);
            if (lISTENNING == null)
            {
                return HttpNotFound();
            }
            return View(lISTENNING);
        }

        // POST: Admin/LISTENNINGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LISTENNING lISTENNING = db.LISTENNINGs.Find(id);
            db.LISTENNINGs.Remove(lISTENNING);
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
