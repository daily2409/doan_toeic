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
    public class PICTUREsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/PICTUREs
        public ActionResult Index()
        {
            return View(db.PICTUREs.ToList());
        }

        // GET: Admin/PICTUREs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PICTURE pICTURE = db.PICTUREs.Find(id);
            if (pICTURE == null)
            {
                return HttpNotFound();
            }
            return View(pICTURE);
        }

        // GET: Admin/PICTUREs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PICTUREs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,URL,NAME")] PICTURE pICTURE)
        {
            if (ModelState.IsValid)
            {
                db.PICTUREs.Add(pICTURE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pICTURE);
        }

        // GET: Admin/PICTUREs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PICTURE pICTURE = db.PICTUREs.Find(id);
            if (pICTURE == null)
            {
                return HttpNotFound();
            }
            return View(pICTURE);
        }

        // POST: Admin/PICTUREs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,URL,NAME")] PICTURE pICTURE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pICTURE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pICTURE);
        }

        // GET: Admin/PICTUREs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PICTURE pICTURE = db.PICTUREs.Find(id);
            if (pICTURE == null)
            {
                return HttpNotFound();
            }
            return View(pICTURE);
        }

        // POST: Admin/PICTUREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PICTURE pICTURE = db.PICTUREs.Find(id);
            db.PICTUREs.Remove(pICTURE);
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
