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
    public class READINGsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/READINGs
        public ActionResult Index()
        {
            var rEADINGs = db.READINGs.Include(r => r.PART);
            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT");
            return View(rEADINGs.ToList());
        }

        // GET: Admin/READINGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            READING rEADING = db.READINGs.Find(id);
            if (rEADING == null)
            {
                return HttpNotFound();
            }
            return View(rEADING);
        }

        // GET: Admin/READINGs/Create
        public ActionResult Create()
        {
            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT");
            return View();
        }

        // POST: Admin/READINGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PAR_ID,CONTENT,LEVEL,TYPE")] READING rEADING)
        {
            if (ModelState.IsValid)
            {
                db.READINGs.Add(rEADING);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT", rEADING.PAR_ID);
            return View(rEADING);
        }

        // GET: Admin/READINGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            READING rEADING = db.READINGs.Find(id);
            if (rEADING == null)
            {
                return HttpNotFound();
            }
            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT", rEADING.PAR_ID);
            return View(rEADING);
        }

        // POST: Admin/READINGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PAR_ID,CONTENT,LEVEL,TYPE")] READING rEADING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEADING).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PAR_ID = new SelectList(db.PARTs, "ID", "CONTENT", rEADING.PAR_ID);
            return View(rEADING);
        }

        // GET: Admin/READINGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            READING rEADING = db.READINGs.Find(id);
            if (rEADING == null)
            {
                return HttpNotFound();
            }
            return View(rEADING);
        }

        // POST: Admin/READINGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            READING rEADING = db.READINGs.Find(id);
            db.READINGs.Remove(rEADING);
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
