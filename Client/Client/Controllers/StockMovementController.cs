using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Configuration;
using System.Linq.Expressions;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Client.Controllers
{
    public class StockMovementController : Controller
    {
        private HttpClient _httpClient;
        private string _URL;
        private static int _page;
        private static int _idItem;
        private static string _type;

        public StockMovementController() 
        {
            _httpClient = new HttpClient();
            _URL = "http://localhost:5069/api/StockMovements/";
        }


        // GET: StockMovementController
        public ActionResult Index()
        {
            try
            {
                _idItem = 0;
                _type = null;
                _page = 0;

                HttpRequestMessage solicitudItem = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5069/Api/Items/"));

                Task<HttpResponseMessage> respuestaItem = _httpClient.SendAsync(solicitudItem);

                respuestaItem.Wait();

                if (respuestaItem.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuestaItem.Result.Content.ReadAsStringAsync().Result;

                    var items = JsonConvert.DeserializeObject<IEnumerable<ItemModel>>(objetoComoTexto);

                    ViewBag.items = new SelectList(items, "Id", "name");
                }

                HttpRequestMessage solicitudTypes = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5069/Api/MovementTypes/"));

                Task<HttpResponseMessage> respuestaTypes = _httpClient.SendAsync(solicitudTypes);

                respuestaTypes.Wait();

                if (respuestaTypes.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuestaTypes.Result.Content.ReadAsStringAsync().Result;

                    var types = JsonConvert.DeserializeObject<IEnumerable<MovementTypeModel>>(objetoComoTexto);

                    ViewBag.movementType = new SelectList(types, "name", "name");
                }


                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri(_URL));
                Task<HttpResponseMessage> respuesta = _httpClient.SendAsync(solicitud);
                respuesta.Wait();


                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;

                    var movements = JsonConvert.DeserializeObject<IEnumerable<StockMovementModel>>(objetoComoTexto);

                    return View(movements);
                }

                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: StockMovementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockMovementController/Create
        public ActionResult Create(string message)
        {

            ViewBag.message = message;

            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5069/Api/Items/"));

            Task <HttpResponseMessage> respuesta = _httpClient.SendAsync(solicitud);

            respuesta.Wait();

            if (respuesta.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;

                var items = JsonConvert.DeserializeObject<IEnumerable<ItemModel>>(objetoComoTexto);

                ViewBag.items = new SelectList(items,"Id","name");
            }

            HttpRequestMessage solicitudTypes = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5069/Api/MovementTypes/"));

            Task<HttpResponseMessage> respuestaTypes = _httpClient.SendAsync(solicitudTypes);

            respuestaTypes.Wait();

            if (respuestaTypes.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuestaTypes.Result.Content.ReadAsStringAsync().Result;

                var types = JsonConvert.DeserializeObject<IEnumerable<MovementTypeModel>>(objetoComoTexto);

                ViewBag.movementType = new SelectList(types,"Id","name");
            }

            return View();
        }

        // POST: StockMovementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockMovementModel movement)
        {
            try
            {
                movement.dateOfMovement = DateTime.Now;

                HttpRequestMessage solicitudType = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5069/Api/MovementTypes/" + movement.movementTypeID));
                Task<HttpResponseMessage> respuestaT = _httpClient.SendAsync(solicitudType);
                respuestaT.Wait();

                if (respuestaT.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuestaT.Result.Content.ReadAsStringAsync().Result;

                    var type = JsonConvert.DeserializeObject<MovementTypeModel>(objetoComoTexto);

                    movement.movementType = type;
                }

                HttpRequestMessage solicitudItem = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5069/Api/Items/" + movement.itemID));
                Task<HttpResponseMessage> respuestaI = _httpClient.SendAsync(solicitudItem);
                respuestaI.Wait();

                if (respuestaI.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuestaI.Result.Content.ReadAsStringAsync().Result;

                    var item = JsonConvert.DeserializeObject<ItemModel>(objetoComoTexto);

                    movement.item = item;
                }

                HttpRequestMessage solicitudCreate = new HttpRequestMessage(HttpMethod.Post, new Uri(_URL));
                string json = JsonConvert.SerializeObject(movement);

                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitudCreate.Content = contenido;

                Task<HttpResponseMessage> respuestaCreate = _httpClient.SendAsync(solicitudCreate);
                respuestaCreate.Wait();

                if (respuestaCreate.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Create", new { message = "Error al crear un movimiento de stock" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Create", new { message = ex.Message});
            }
        }

        // GET: StockMovementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockMovementController/Edit/5
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

        // GET: StockMovementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockMovementController/Delete/5
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
        public ActionResult Movements(int idItem, string type)
        {
            try 
            {
                _idItem=idItem;
                _type=type;
              
                if (_page < 1) { _page = 1; }

                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri(_URL + idItem + ", " + type + " , " +_page));
                Task<HttpResponseMessage> respuesta = _httpClient.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;

                    var movements = JsonConvert.DeserializeObject<IEnumerable<StockMovementModel>>(objetoComoTexto);

                    return View(movements);
                }

                return View(nameof(Index));

            }catch (Exception ex)
            {
                return RedirectToAction("Movements", new { message = ex.Message});
            }                
        }

        public ActionResult Movements()
        {
            try
            {
                if (_page < 1) { _page = 1; }

                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri(_URL + _idItem + ", " + _type + " , " + _page));
                Task<HttpResponseMessage> respuesta = _httpClient.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;

                    var movements = JsonConvert.DeserializeObject<IEnumerable<StockMovementModel>>(objetoComoTexto);

                    return View(movements);
                }

                return View(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
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

                return RedirectToAction("Movements");
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

                if (_page >=  1)
                {
                    return RedirectToAction("Movements");
                }
                else 
                {
                    return RedirectToAction("Index");
                }                          

                
            }
            catch 
            {
                return RedirectToAction("Index", "StockMovement");
            }
        }

    }
}
