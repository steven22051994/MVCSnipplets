using Snipplets.Models;
using Snipplets.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snipplets.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> EmployeeListe = new List<Employee>();
        


        // GET: Employee
        public ActionResult Index()
        {
            return View(EmployeeListe);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var ElemToDisplay = EmployeeListe.Where(x => x.Id == id).FirstOrDefault();
            return View(ElemToDisplay);
        }

        // GET: Employee/PartialDetails
        public ActionResult PartialDetails()
        {
            TempData["Anzahl"] = EmployeeListe.Count();
            return View(EmployeeListe);
        }

        // GET: Employee/PartialDetails
        public ActionResult SummaryDetails()
        {
            // Be careful: RenderPartial just calls the View ... not the action ... 
            
            
            return View();
        }

        // GET: Employee/PartialDetails
        public ActionResult EmployeeData(int id)
        {
            // Be careful: RenderPartial just calls the View ... not the action ... 

            var ElemToViewPartial = EmployeeListe.Where(z => z.Id == id).FirstOrDefault();
            return View(ElemToViewPartial);
        }
        // GET: Employee/Create
        public ActionResult Upload(int id)
        {
            TempData["idupload"] = id;
            
            return View();
        }




        // POST: Employee/Create
        [HttpPost]
        public ActionResult UploadFile(UploadViewModel uploadViewModel)
        {
            try
            {

                // const string pathtostore = @"d:\VisualStudio2019\Uploads";
                ViewBag.FileError = "";
                ViewBag.Exception = "None";

                if (uploadViewModel.file.ContentLength > 0 )
                {
                    string _Filename = Path.GetFileName(uploadViewModel.file.FileName);

                    //Check if filetype JPEG is given: 

                    if (uploadViewModel.file.ContentType != "image/jpeg" )
                    {
                        ViewBag.FileError = "Only JPG / JPEG files are allowed";

                        return View();
                    }
                       


                    // if (Directory.Exists(pathtostore))
                    // {
                        // 1. VARIANT:  Choose and allowed path: 
                        // string _Path = Path.Combine(Server.MapPath(pathtostore), _Filename);

                        // 2. VARIANT: To save the file within the Projekt:
                        string _Path = Path.Combine(Server.MapPath("~/UploadedFiles"), _Filename);
                        uploadViewModel.file.SaveAs(_Path);
                        
                        var elemToEdit = Snipplets.Controllers.EmployeeController.EmployeeListe.Where
                            (x => x.Id == (int)TempData["idupload"]).FirstOrDefault();

                        elemToEdit.FileNamePicture = _Filename;

                    // }

                    // else
                    
                     //    throw new Exception("PathError");


                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.Message;
                
                return View();
            }
        }



        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }



       
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                employee.Id = EmployeeListe.Count() + 1;
                employee.Active = true;



                EmployeeListe.Add(employee);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
