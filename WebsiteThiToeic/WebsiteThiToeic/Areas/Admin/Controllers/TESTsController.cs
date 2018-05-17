using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteThiToeic.Access.EF;

namespace WebsiteThiToeic.Areas.Admin.Controllers
{
    public class TESTsController : Controller
    {
        private readonly Db db = new Db();

        // GET: Admin/TESTs
        public ActionResult Index()
        {
            return View(db.TESTs.ToList());
        }

        // GET: Admin/TESTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tEST = db.TESTs.Find(id);
            if (tEST == null) return HttpNotFound();
            return View(tEST);
        }

        // GET: Admin/TESTs/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult _Create(int level)
        {
            var lISTENNING = new LISTENNING();
            ViewBag.PAR_ID = new SelectList(db.PARTs, "VALUE", "CONTENT", lISTENNING.PAR_ID);
            ViewBag.level = level;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create([Bind(Include = "ID,PAR_ID,LISTEN_URL,NAME,PICTURE_URL,CORRECT_ANSWER,LEVEL,TYPE")]
            LISTENNING lISTENNING/* int level*/)
        {
            //if (ModelState.IsValid)
            //{
            //    var f = Request.Files[0];
            //    var fimage = Request.Files[1];
            //    var fileName = string.Empty;
            //    var IfileName = string.Empty;

            //    if (f.ContentLength != 0)
            //    {
            //        fileName = Path.GetFileName(f.FileName);
            //        var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
            //        f.SaveAs(path);
            //    }

            //    if (fimage.ContentLength != 0)
            //    {
            //        IfileName = Path.GetFileName(fimage.FileName);
            //        var ipath = Path.Combine(Server.MapPath("~/Uploads/Image"), IfileName);
            //        fimage.SaveAs(ipath);
            //    }

            //    lISTENNING.LISTEN_URL = fileName;
            //    lISTENNING.PICTURE_URL = IfileName;
            //    lISTENNING.LEVEL = level;
            //    db.LISTENNINGs.Add(lISTENNING);

            //    db.SaveChanges();
            //    //return RedirectToAction("_Create", new {level});
            //    return Json(new { status=1});
            //}

            //ViewBag.PAR_ID = new SelectList(db.PARTs, "VALUE", "CONTENT", lISTENNING.PAR_ID);
            //return View(lISTENNING);

            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                               fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                var vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var vContext = new ViewContext(ControllerContext, vResult.View, ViewData, new TempDataDictionary(),
                    writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }

        // POST: Admin/TESTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,CREATE_DATE,LEVEL")]
            TEST tEST)
        {
            if (ModelState.IsValid)
            {
                db.TESTs.Add(tEST);
                db.SaveChanges();

                return RedirectToAction("_Create", new {level = tEST.LEVEL});
            }

            return View(tEST);
        }

        // GET: Admin/TESTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tEST = db.TESTs.Find(id);
            if (tEST == null) return HttpNotFound();
            return View(tEST);
        }

        // POST: Admin/TESTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,CREATE_DATE,LEVEL")]
            TEST tEST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEST);
        }

        // GET: Admin/TESTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tEST = db.TESTs.Find(id);
            if (tEST == null) return HttpNotFound();
            return View(tEST);
        }

        // POST: Admin/TESTs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tEST = db.TESTs.Find(id);
            db.TESTs.Remove(tEST);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}