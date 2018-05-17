using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteThiToeic.Access.EF;
using Biz.Lib.Helpers; 
using PagedList;
using PagedList.Mvc;

namespace WebsiteThiToeic.Controllers
{
    public class LearnController : Controller
    {
        private Db db = new Db();
        // GET: Learn
        public ActionResult Index()
        {
            return View();
        }
           
        // GET: Learn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Learn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Learn/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Learn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Learn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Learn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Learn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Part1(/*int? level*/int? page)
        {
            ;
            int level = 1;
            int pageSize = 1;
            int pageNunber = (page ?? 1);
                var model = db.LISTENNINGs.Where(x => x.PAR_ID == 3).Where(x => x.LEVEL == level);
            return View(model.OrderBy(x=>x.ID).ToPagedList(pageNunber,pageSize));
           
        }
    }
}
