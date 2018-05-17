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
    public class THEMEsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/THEMEs
        public ActionResult Index()
        {
            return View(db.THEMEs.ToList());
        }

        // GET: Admin/THEMEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEME tHEME = db.THEMEs.Find(id);
            if (tHEME == null)
            {
                return HttpNotFound();
            }
            return View(tHEME);
        }

        // GET: Admin/THEMEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/THEMEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CONTENT")] THEME tHEME)
        {
            if (ModelState.IsValid)
            {
                db.THEMEs.Add(tHEME);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHEME);
        }

        // GET: Admin/THEMEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEME tHEME = db.THEMEs.Find(id);
            if (tHEME == null)
            {
                return HttpNotFound();
            }
            return View(tHEME);
        }

        // POST: Admin/THEMEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CONTENT")] THEME tHEME)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHEME).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHEME);
        }

        // GET: Admin/THEMEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEME tHEME = db.THEMEs.Find(id);
            if (tHEME == null)
            {
                return HttpNotFound();
            }
            return View(tHEME);
        }

        // POST: Admin/THEMEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THEME tHEME = db.THEMEs.Find(id);
            db.THEMEs.Remove(tHEME);
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
