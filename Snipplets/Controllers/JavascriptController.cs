using Snipplets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snipplets.Controllers
{
    public class JavascriptController : Controller
    {
        public static Javascript OneJSObject = new Javascript();

        // GET: Javascript
        public ActionResult Index()
        {
            return View(OneJSObject);
        }

        public ActionResult UeberUns()
        {
            Snipplets.MvcApplication.WriteCookiewithMVC();
            return View(OneJSObject);
        }

        // GET: Javascript/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Javascript/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Javascript/Create
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

        // GET: Javascript/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Javascript/Edit/5
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

        // GET: Javascript/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Javascript/Delete/5
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
