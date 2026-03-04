using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Client.Controllers
{
    public class SummaryController : Controller
    {

        private string _URL;
        private HttpClient _client;
        private static int _page;
        public SummaryController()
        {
            _client = new HttpClient();
            _URL = "http://localhost:5069/api/Summary/";
        }

        // GET: SummaryController
        public ActionResult Index()
        {
            try
            {
                if (_page < 1) { _page = 1; }

                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri(_URL));

                Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);

                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;

                    var summarys = JsonConvert.DeserializeObject<IEnumerable<SummaryModel>>(objetoComoTexto);

                    return View(summarys);
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: SummaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SummaryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SummaryController/Create
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

        // GET: SummaryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SummaryController/Edit/5
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

        // GET: SummaryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SummaryController/Delete/5
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
    }
}
