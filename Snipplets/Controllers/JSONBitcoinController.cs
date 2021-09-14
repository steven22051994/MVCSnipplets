using Snipplets.Models;
using Snipplets.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Snipplets.Controllers
{
    public class JSONBitcoinController : Controller
    {
        public static List<JSONBitcoin> JSONBitcoinListe = new List<JSONBitcoin>();
        public static String JSONResultSnipplet;
        public static BuySellViewModel buySellViewModel = new BuySellViewModel();

        // GET: JSONBitcoin
        public ActionResult Index()
        {
            return View(JSONBitcoinListe);
        }


        private async System.Threading.Tasks.Task GetJSONAsync(BuySellViewModel buySellViewModel)
        {
            using (var httpClient = new HttpClient())
            {
                JSONResultSnipplet = await httpClient.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice.json");

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                dynamic JSONFinal = javaScriptSerializer.Deserialize<object>(JSONResultSnipplet);

                
                var JSONDBData = new JSONBitcoin();

                JSONDBData.Active = true;
                JSONDBData.Amount = buySellViewModel.AmountEUR;
                JSONDBData.ChartName = JSONFinal["chartName"];
                JSONDBData.PriceEur = (float) JSONFinal["bpi"]["EUR"]["rate_float"];
                JSONDBData.Time = JSONFinal["time"]["updated"];
                JSONDBData.Id = JSONBitcoinListe.Count() + 1;

                if (buySellViewModel.BuySellAssets == transType.BuyAssets)
                    JSONDBData.Transaction = action.bought;
                else
                    JSONDBData.Transaction = action.sold;

                JSONBitcoinListe.Add(JSONDBData);

                /* "{\"time\":{\"updated\":\"Oct 29, 2020 20:55:00 UTC\",\"updatedISO\":\"2020-10-29T20:55:00+00:00\",\"updateduk\":\"Oct 29, 2020 at 20:55 GMT\"},
                 * \"disclaimer\":\"This data was produced from the CoinDesk Bitcoin Price Index (USD). Non-USD currency data converted using hourly conversion rate from openexchangerates.org\",
                 * \"chartName\":\"Bitcoin\",
                 * \"bpi\":
                 *          {\"USD\":{\"code\":\"USD\",\"symbol\":\"&#36;\",\"rate\":\"13,473.7222\",\"description\":\"United States Dollar\",\"rate_float\":13473.7222},
                 *           \"GBP\":{\"code\":\"GBP\",\"symbol\":\"&pound;\",\"rate\":\"10,419.0272\",\"description\":\"British Pound Sterling\",\"rate_float\":10419.0272},
                 *           \"EUR\":{\"code\":\"EUR\",\"symbol\":\"&euro;\",\"rate\":\"11,541.2940\",\"description\":\"Euro\",\"rate_float\":11541.294}}}"
                */

               
            }
        }

        // GET: JSONBitcoin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: JSONBitcoin/Details/5
        public async System.Threading.Tasks.Task<ActionResult> BuySell()
        { 

            var obj = new BuySellViewModel();
            return View(obj);

        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> BuySell(BuySellViewModel buySellViewModel)
        {
            await GetJSONAsync(buySellViewModel);

            return RedirectToAction("Index");

        }

        // GET: JSONBitcoin/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: JSONBitcoin/Create
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

        // GET: JSONBitcoin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JSONBitcoin/Edit/5
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

        // GET: JSONBitcoin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JSONBitcoin/Delete/5
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
