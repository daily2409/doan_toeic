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
    public class PARTsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/PARTs
        public ActionResult Index()
        {
            var pARTs = db.PARTs.Include(p => p.TITLE);
            return View(pARTs.ToList());
        }

        // GET: Admin/PARTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PART pART = db.PARTs.Find(id);
            if (pART == null)
            {
                return HttpNotFound();
            }
            return View(pART);
        }

        // GET: Admin/PARTs/Create
        public ActionResult Create()
        {
            ViewBag.TIT_ID = new SelectList(db.TITLEs, "ID", "CONTENT");
            return View();
        }

        // POST: Admin/PARTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TIT_ID,CONTENT,VALUE")] PART pART)
        {
            if (ModelState.IsValid)
            {
                db.PARTs.Add(pART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TIT_ID = new SelectList(db.TITLEs, "ID", "CONTENT", pART.TIT_ID);
            return View(pART);
        }

        // GET: Admin/PARTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PART pART = db.PARTs.Find(id);
            if (pART == null)
            {
                return HttpNotFound();
            }
            ViewBag.TIT_ID = new SelectList(db.TITLEs, "ID", "CONTENT", pART.TIT_ID);
            return View(pART);
        }

        // POST: Admin/PARTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TIT_ID,CONTENT,VALUE")] PART pART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TIT_ID = new SelectList(db.TITLEs, "ID", "CONTENT", pART.TIT_ID);
            return View(pART);
        }

        // GET: Admin/PARTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PART pART = db.PARTs.Find(id);
            if (pART == null)
            {
                return HttpNotFound();
            }
            return View(pART);
        }

        // POST: Admin/PARTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PART pART = db.PARTs.Find(id);
            db.PARTs.Remove(pART);
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
