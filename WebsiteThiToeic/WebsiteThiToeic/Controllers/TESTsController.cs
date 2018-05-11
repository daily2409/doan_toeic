using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteThiToeic.Access.EF;

namespace WebsiteThiToeic.Controllers
{
    public class TESTsController : Controller
    {
        private Db db = new Db();

        // GET: TESTs
        public ActionResult Index()
        {
            var tESTs = db.TESTs.Include(t => t.LISTENNING).Include(t => t.READING);
            return View(tESTs.ToList());
        }

        // GET: TESTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEST tEST = db.TESTs.Find(id);
            if (tEST == null)
            {
                return HttpNotFound();
            }
            return View(tEST);
        }

        // GET: TESTs/Create
        public ActionResult Create()
        {
            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL");
            ViewBag.RED_ID = new SelectList(db.READINGs, "ID", "CONTENT");
            return View();
        }

        // POST: TESTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LIS_ID,RED_ID")] TEST tEST)
        {
            if (ModelState.IsValid)
            {
                db.TESTs.Add(tEST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL", tEST.LIS_ID);
            ViewBag.RED_ID = new SelectList(db.READINGs, "ID", "CONTENT", tEST.RED_ID);
            return View(tEST);
        }

        // GET: TESTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEST tEST = db.TESTs.Find(id);
            if (tEST == null)
            {
                return HttpNotFound();
            }
            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL", tEST.LIS_ID);
            ViewBag.RED_ID = new SelectList(db.READINGs, "ID", "CONTENT", tEST.RED_ID);
            return View(tEST);
        }

        // POST: TESTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LIS_ID,RED_ID")] TEST tEST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL", tEST.LIS_ID);
            ViewBag.RED_ID = new SelectList(db.READINGs, "ID", "CONTENT", tEST.RED_ID);
            return View(tEST);
        }

        // GET: TESTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEST tEST = db.TESTs.Find(id);
            if (tEST == null)
            {
                return HttpNotFound();
            }
            return View(tEST);
        }

        // POST: TESTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEST tEST = db.TESTs.Find(id);
            db.TESTs.Remove(tEST);
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
