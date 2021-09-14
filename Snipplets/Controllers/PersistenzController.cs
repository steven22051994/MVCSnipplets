using Snipplets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace Snipplets.Controllers
{
    public class PersistenzController : Controller
    {
        // GET: Persistenz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Load()
        {
            Snipplets.MvcApplication.Persitenz.Load();          
            TempData["Message"] = "Data loaded";
            return RedirectToAction("Index");
        }

        public ActionResult Save()
        {
            Snipplets.MvcApplication.Persitenz.Store();
            TempData["Message"] = "Data saved";
            return RedirectToAction("Index");
        }

        public ActionResult Clean()
        {
            // CleanUp UploadedFiles folder ... 

            string _Path = Server.MapPath("~/UploadedFiles");

            DirectoryInfo dir = new DirectoryInfo(_Path);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }



            TempData["Message"] = "Uploaded Files folder cleaned up";
            return RedirectToAction("Index");
        }



    }
}