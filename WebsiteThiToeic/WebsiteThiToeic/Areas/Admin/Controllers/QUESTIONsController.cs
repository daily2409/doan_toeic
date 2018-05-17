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
    public class QUESTIONsController : Controller
    {
        private Db db = new Db();

        // GET: Admin/QUESTIONs
        public ActionResult Index()
        {
            var qUESTIONS = db.QUESTIONS.Include(q => q.LISTENNING).Include(q => q.READING);
            return View(qUESTIONS.ToList());
        }

        // GET: Admin/QUESTIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUESTION qUESTION = db.QUESTIONS.Find(id);
            if (qUESTION == null)
            {
                return HttpNotFound();
            }
            return View(qUESTION);
        }

        // GET: Admin/QUESTIONs/Create
        public ActionResult Create()
        {
            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL");
            ViewBag.REA_ID = new SelectList(db.READINGs, "ID", "CONTENT");
            return View();
        }

        // POST: Admin/QUESTIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,REA_ID,LIS_ID,CONTENT,ANSWER_A,ANSWER_B,ANSWER_C,ANSWER_D,CORRECT_ANSWER")] QUESTION qUESTION)
        {
            if (ModelState.IsValid)
            {
                db.QUESTIONS.Add(qUESTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL", qUESTION.LIS_ID);
            ViewBag.REA_ID = new SelectList(db.READINGs, "ID", "CONTENT", qUESTION.REA_ID);
            return View(qUESTION);
        }

        // GET: Admin/QUESTIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUESTION qUESTION = db.QUESTIONS.Find(id);
            if (qUESTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL", qUESTION.LIS_ID);
            ViewBag.REA_ID = new SelectList(db.READINGs, "ID", "CONTENT", qUESTION.REA_ID);
            return View(qUESTION);
        }

        // POST: Admin/QUESTIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,REA_ID,LIS_ID,CONTENT,ANSWER_A,ANSWER_B,ANSWER_C,ANSWER_D,CORRECT_ANSWER")] QUESTION qUESTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUESTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LIS_ID = new SelectList(db.LISTENNINGs, "ID", "LISTEN_URL", qUESTION.LIS_ID);
            ViewBag.REA_ID = new SelectList(db.READINGs, "ID", "CONTENT", qUESTION.REA_ID);
            return View(qUESTION);
        }

        // GET: Admin/QUESTIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUESTION qUESTION = db.QUESTIONS.Find(id);
            if (qUESTION == null)
            {
                return HttpNotFound();
            }
            return View(qUESTION);
        }

        // POST: Admin/QUESTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUESTION qUESTION = db.QUESTIONS.Find(id);
            db.QUESTIONS.Remove(qUESTION);
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
