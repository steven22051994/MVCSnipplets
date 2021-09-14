using Snipplets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Snipplets.Controllers
{
    public class JSONDataController : Controller
    {
        public static List<Data> dataListe = new List<Data>();
        public static int Version = 1;
        public static string pfadJSON = @"d:\JSONData.bin";

        // GET: JSONData
        public ActionResult Index()
        {
            // Get data from JSON source  ... 
            HandleJSONPersistence(null);

            var active_List = new List<Data>();

            active_List = dataListe.Where(x => x.Active == true).ToList();

            return View(active_List);
        }

        // GET: JSONData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JSONData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JSONData/Create
        [HttpPost]
        public ActionResult Create(Data data)
        {
            try
            {
                // TODO: Add insert logic here
                // var JSONToWrite = PrepareNewJSON(data);
                if (!HandleJSONPersistence(data))
                    return View();
                
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public bool HandleJSONPersistence (Data data)
        {
            
            
            // JSON File exists? 
            if (System.IO.File.Exists(pfadJSON))
            {
                try
                {
                    FileStream fs = new FileStream(pfadJSON, FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();

                    var OurPersistedJSON = (string)formatter.Deserialize(fs);

                    // Now convert the JSONToWrite to JSON string ... 
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    var JSONFinal = javaScriptSerializer.Deserialize<JSONData>(OurPersistedJSON);

                    if (JSONFinal.JSONVersion == 1)
                    {
                        dataListe = JSONFinal.data;


                        // Create new element on top of existing ?? 

                        if (data != null)
                        {
                            var UpdatedFullJSONDB = new JsonResult();
                            
                            UpdatedFullJSONDB = PrepareNewJSON(data);

                            // ok, now save it again .... 

                            fs.Close();

                            FileStream fs2 = new FileStream(pfadJSON, FileMode.Create);
                            BinaryFormatter formatter2 = new BinaryFormatter();
                            formatter2.Serialize(fs2, UpdatedFullJSONDB.Data);

                            fs2.Close();


                        }

                        fs.Close();

                    }
                    else
                    {

                        fs.Close();
                        // Version not implemented yet
                        return false;

                    }


                    // Now check the Version ...

                    // JSONFileContent.

                    fs.Close();

                    return true;
                } 
                catch (Exception e)
                {
                    ViewData["Problem"] = e.Message.ToString();

                }

                return false;
                

            }
            else // JSON File not existing
            {
                if (data == null)
                    return false;
                
                var jsonString = PrepareNewJSON(data);
                
                FileStream fs = new FileStream(pfadJSON, FileMode.Create);
                // Take a snapshot of all objects to store
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, jsonString.Data);

                    fs.Close();

                }
                catch (Exception e)
                {
                    fs.Close();
                    // Somethings wrong!! 
                    return false;
                }



                return true;
            }

            
        }

        // GET: JSONData/Create
        public JsonResult PrepareNewJSON(Data data)
        {

            // JSON File does not exist 
            var JSONToWrite = new JSONData()
            {
                Id = 1,
                JSONVersion = Version
            };

            Data tempdata = new Data();

            tempdata.Id = dataListe.Count() + 1;
            tempdata.ArticleText = data.ArticleText;
            tempdata.UserName = data.UserName;

            dataListe.Add(tempdata);

            JSONToWrite.data = dataListe;

            // Now convert the JSONToWrite to JSON string ... 
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var JSONString = javaScriptSerializer.Serialize(JSONToWrite);

            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }



        public bool UpdateJSONPersistence(Data data)
        {


            // JSON File exists? 
            if (System.IO.File.Exists(pfadJSON))
            {
                try
                {
                    FileStream fs = new FileStream(pfadJSON, FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();

                    var OurPersistedJSON = (string)formatter.Deserialize(fs);

                    // Now convert the JSONToWrite to JSON string ... 
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    var JSONFinal = javaScriptSerializer.Deserialize<JSONData>(OurPersistedJSON);

                    if (JSONFinal.JSONVersion == 1)
                    {
                        // dataListe = JSONFinal.data;


                        // Update existing 

                        if (data != null)
                        {
                            var UpdatedFullJSONDB = new JsonResult();

                            UpdatedFullJSONDB = PrepareUpdateJSON();

                            // ok, now save it again .... 

                            fs.Close();

                            FileStream fs2 = new FileStream(pfadJSON, FileMode.Create);
                            BinaryFormatter formatter2 = new BinaryFormatter();
                            formatter2.Serialize(fs2, UpdatedFullJSONDB.Data);

                            fs2.Close();
                        }

                        fs.Close();
                    }
                    else
                    {
                        fs.Close();
                        // Version not implemented yet
                        return false;
                    }



                    fs.Close();

                    return true;
                }
                catch (Exception e)
                {
                    ViewData["Problem"] = e.Message.ToString();

                }

                return false;


            }
            else // JSON File not existing
            {
                if (data == null)
                    return false;

                var jsonString = PrepareNewJSON(data);

                FileStream fs = new FileStream(pfadJSON, FileMode.Create);
                // Take a snapshot of all objects to store
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, jsonString.Data);

                    fs.Close();

                }
                catch (Exception e)
                {
                    fs.Close();
                    // Somethings wrong!! 
                    return false;
                }



                return true;
            }


        }

        // GET: JSONData/Create
        public JsonResult PrepareUpdateJSON()
        {

            // JSON File does not exist 
            var JSONToWrite = new JSONData()
            {
                Id = 1,
                JSONVersion = Version
            };


            JSONToWrite.data = dataListe;

            // Now convert the JSONToWrite to JSON string ... 
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var JSONString = javaScriptSerializer.Serialize(JSONToWrite);

            return Json(JSONString, JsonRequestBehavior.AllowGet);
        }



        // GET: JSONData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JSONData/Edit/5
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

        // GET: JSONData/Delete/5
        public ActionResult Delete(int id)
        {
            var ItemToDelete = dataListe.Where(z => z.Id == id).FirstOrDefault();
            
            return View(ItemToDelete);
        }

        // POST: JSONData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var ItemToDelete = dataListe.Where(z => z.Id == id).FirstOrDefault();
                ItemToDelete.Active = false;
                UpdateJSONPersistence(ItemToDelete);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
