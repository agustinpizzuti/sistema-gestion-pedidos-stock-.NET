using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Client.Controllers
{
    public class ItemController : Controller
    {
        private string _URL;
        private HttpClient _client;
        private static int _page;
        private static string _dateOne;
        private static string _dateTwo;

        public ItemController() 
        {
            _client = new HttpClient();
            _URL = "http://localhost:5069/Api/Items/";          
        }

        // GET: ItemController
        [HttpPost]
        public ActionResult Index(DateTime dateOne, DateTime dateTwo)
        {
            try
            {
                if (dateOne == DateTime.MinValue || dateTwo == DateTime.MinValue)
                {
                    return RedirectToAction("Index", "StockMovement");
                }
                if (dateOne > dateTwo)
                {
                    return RedirectToAction("Index", "StockMovement");
                }

                string monthDO = dateOne.Month.ToString();
                string dayDO=dateOne.Day.ToString();
                string yearDO = dateOne.Year.ToString();

                string monthDT=dateTwo.Month.ToString();
                string dayDT=dateTwo.Day.ToString();
                string yearDT = dateTwo.Year.ToString();

                string guion = "-";

                string dateOneComplete = monthDO + guion + dayDO + guion + yearDO;
                string dateTwoComplete = monthDT + guion + dayDT + guion + yearDT;


                _dateOne = dateOneComplete;
                _dateTwo = dateTwoComplete;

                if (_page < 1) { _page = 1; }

                HttpRequestMessage solicitudItem = new HttpRequestMessage(HttpMethod.Get, new Uri(_URL + dateOneComplete+", "  +dateTwoComplete+" , " + _page));

                Task<HttpResponseMessage> respuestaItem = _client.SendAsync(solicitudItem);

                respuestaItem.Wait();

                if (respuestaItem.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuestaItem.Result.Content.ReadAsStringAsync().Result;

                    var items = JsonConvert.DeserializeObject<IEnumerable<ItemModel>>(objetoComoTexto);

                    return View(items);
                }

                return View();
            }
            catch
            {
                return View();
            }        
        }

        public ActionResult Index()
        {
            try
            {
                if (_page < 1) { _page = 1; }

                HttpRequestMessage solicitudItem = new HttpRequestMessage(HttpMethod.Get, new Uri(_URL + _dateOne + ", " + _dateTwo + " , " + _page));

                Task<HttpResponseMessage> respuestaItem = _client.SendAsync(solicitudItem);

                respuestaItem.Wait();

                if (respuestaItem.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuestaItem.Result.Content.ReadAsStringAsync().Result;

                    var items = JsonConvert.DeserializeObject<IEnumerable<ItemModel>>(objetoComoTexto);

                    return View(items);
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Next()
        {
            try
            {
                _page++;

                if (_page < 0)
                {
                    _page = 1;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "StockMovement");
            }
        }

        [HttpPost]
        public ActionResult Previous()
        {
            try
            {

                _page--;

                if (_page < 0)
                {
                    _page = 1;
                }

                if (_page >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index","StockMovement");
                }


            }
            catch
            {
                return RedirectToAction("Index", "StockMovement");
            }
        }

    }
}
