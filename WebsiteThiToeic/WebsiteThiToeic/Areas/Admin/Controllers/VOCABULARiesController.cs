using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteThiToeic.Access.EF;

namespace WebsiteThiToeic.Areas.Admin.Controllers
{
    public class VOCABULARiesController : Controller
    {
        private Db db = new Db();

        // GET: Admin/VOCABULARies
        public ActionResult Index()
        {
            var vOCABULARies = db.VOCABULARies.Include(v => v.PICTURE).Include(v => v.THEME);
            return View(vOCABULARies.ToList());
        }

        // GET: Admin/VOCABULARies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOCABULARY vOCABULARY = db.VOCABULARies.Find(id);
            if (vOCABULARY == null)
            {
                return HttpNotFound();
            }
            return View(vOCABULARY);
        }

        // GET: Admin/VOCABULARies/Create
        public ActionResult Create()
        {
            ViewBag.PIC_ID = new SelectList(db.PICTUREs, "ID", "URL");
            ViewBag.THE_ID = new SelectList(db.THEMEs, "ID", "CONTENT");
            return View();
        }

        // POST: Admin/VOCABULARies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PIC_ID,THE_ID,WORD,NOUN,VERB,ADJECTIVE,ADVERB,SYNONYM")] VOCABULARY vOCABULARY)
        {
            if (ModelState.IsValid)
            {
                db.VOCABULARies.Add(vOCABULARY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PIC_ID = new SelectList(db.PICTUREs, "ID", "URL", vOCABULARY.PIC_ID);
            ViewBag.THE_ID = new SelectList(db.THEMEs, "ID", "CONTENT", vOCABULARY.THE_ID);
            return View(vOCABULARY);
        }

        // GET: Admin/VOCABULARies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOCABULARY vOCABULARY = db.VOCABULARies.Find(id);
            if (vOCABULARY == null)
            {
                return HttpNotFound();
            }
            ViewBag.PIC_ID = new SelectList(db.PICTUREs, "ID", "URL", vOCABULARY.PIC_ID);
            ViewBag.THE_ID = new SelectList(db.THEMEs, "ID", "CONTENT", vOCABULARY.THE_ID);
            return View(vOCABULARY);
        }

        // POST: Admin/VOCABULARies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PIC_ID,THE_ID,WORD,NOUN,VERB,ADJECTIVE,ADVERB,SYNONYM")] VOCABULARY vOCABULARY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vOCABULARY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PIC_ID = new SelectList(db.PICTUREs, "ID", "URL", vOCABULARY.PIC_ID);
            ViewBag.THE_ID = new SelectList(db.THEMEs, "ID", "CONTENT", vOCABULARY.THE_ID);
            return View(vOCABULARY);
        }

        // GET: Admin/VOCABULARies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOCABULARY vOCABULARY = db.VOCABULARies.Find(id);
            if (vOCABULARY == null)
            {
                return HttpNotFound();
            }
            return View(vOCABULARY);
        }

        // POST: Admin/VOCABULARies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VOCABULARY vOCABULARY = db.VOCABULARies.Find(id);
            db.VOCABULARies.Remove(vOCABULARY);
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
