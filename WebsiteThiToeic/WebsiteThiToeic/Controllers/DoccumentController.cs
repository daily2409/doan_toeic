using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteThiToeic.Controllers
{
    public class DoccumentController : Controller
    {
        // GET: Doccument
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doccument/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doccument/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doccument/Create
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

        // GET: Doccument/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doccument/Edit/5
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

        // GET: Doccument/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doccument/Delete/5
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
    }
}
