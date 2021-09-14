using Snipplets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Snipplets
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Add one Element 
            Snipplets.Controllers.EmployeeController.EmployeeListe.Add(
            new Employee()
            {
                Id = 1,
                Active = true,
                Age = 48,
                Sex = SexType.Male,
                FileNamePicture = "",
                FirstName = "Walter",
                LastName = "Der Weise"

            });

            Snipplets.Controllers.EmployeeController.EmployeeListe.Add(
            new Employee()
            {
                Id = 2,
                Active = true,
                Age = 34,
                Sex = SexType.Female,
                FileNamePicture = "",
                FirstName = "Nathanja",
                LastName = "Die Kluge"

            });


        }

        public static class Persitenz
        {
            public static List<Object> OurObjectsToPersist = new List<Object>();
            static string pfadpersistenz = @"d:\OliverAppDaten.bin";

            public static void Init()
            {
                // First - Initialize - Clear all items in the list 
                OurObjectsToPersist.Clear();

                // TODO - Check if File Path is avaliable ...
            }



            public static bool Store()
            {
                // Clear List 
                Init();

                FileStream fs = new FileStream(pfadpersistenz, FileMode.Create);

                // Take a snapshot of all objects to store
                try
                {
                    OurObjectsToPersist.Add(Snipplets.Controllers.EmployeeController.EmployeeListe);

                    // Any other ??? 
                    // OurObjectsToPersist.Add(Snipplets.Controllers.EmployeeController.EmployeeListe);



                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, OurObjectsToPersist);

                    fs.Close();
                    return true;

                }
                catch
                {
                    fs.Close();
                    // Somethings wrong!! 
                    return false;
                }
            }

            public static bool Load()
            {

                if (System.IO.File.Exists(pfadpersistenz))
                {
                    FileStream fs = new FileStream(pfadpersistenz, FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();

                    OurObjectsToPersist = (List<Object>)formatter.Deserialize(fs);

                    Snipplets.Controllers.EmployeeController.EmployeeListe = (List<Employee>)OurObjectsToPersist[0];

                    fs.Close();

                    return true;
                }
                else
                {
                    // Somethings wrong!! 
                    return false;

                }


            }

            public static bool Reset()
            {
                try
                {
                    if (System.IO.File.Exists(pfadpersistenz))
                    {
                        System.IO.File.Delete(pfadpersistenz);
                    }

                    OurObjectsToPersist.Clear();
                    return true;

                }

                catch
                {
                    return false;
                }

            }


        }
        public static void WriteCookiewithMVC()
        {


            // Now write the current time to the cookie

            HttpCookie cookienew = new HttpCookie("todoAPP");

            cookienew.Value = "Today is a good day ... now change me to an JSON string ánd try it again ;)";
            cookienew.Expires = DateTime.Now.AddHours(1);

            HttpContext.Current.Response.SetCookie(cookienew);


        }
    }
}
