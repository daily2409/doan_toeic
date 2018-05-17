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
    public class TITLEsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/TITLEs
        public ActionResult Index()
        {
            return View(db.TITLEs.ToList());
        }

        // GET: Admin/TITLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TITLE tITLE = db.TITLEs.Find(id);
            if (tITLE == null)
            {
                return HttpNotFound();
            }
            return View(tITLE);
        }

        // GET: Admin/TITLEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TITLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CONTENT")] TITLE tITLE)
        {
            if (ModelState.IsValid)
            {
                db.TITLEs.Add(tITLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tITLE);
        }

        // GET: Admin/TITLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TITLE tITLE = db.TITLEs.Find(id);
            if (tITLE == null)
            {
                return HttpNotFound();
            }
            return View(tITLE);
        }

        // POST: Admin/TITLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CONTENT")] TITLE tITLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tITLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tITLE);
        }

        // GET: Admin/TITLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TITLE tITLE = db.TITLEs.Find(id);
            if (tITLE == null)
            {
                return HttpNotFound();
            }
            return View(tITLE);
        }

        // POST: Admin/TITLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TITLE tITLE = db.TITLEs.Find(id);
            db.TITLEs.Remove(tITLE);
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
