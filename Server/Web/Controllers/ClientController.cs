using AppLogic.DTOs;
using AppLogic.UseCaseInterface.ClientsCU;
using AppLogic.UseCaseInterface.OrdersCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ClientController : Controller
    {
        private IFindAllClientsCU _findAllClientCU;
        private IFindClientsByNameCU _findAllByNameCU;
        private IFindClientsBySurenameCU _findAllBySurenameCU;
        private IFindClientsByAmountCU _findClientsByAmountCU;
        public ClientController(IFindAllClientsCU findAllClientCU, IFindClientsByNameCU findAllByNameCU, 
            IFindClientsBySurenameCU findAllBySurenameCU,IFindClientsByAmountCU findClientsByAmountCU)
        {
            _findAllClientCU = findAllClientCU;
            _findAllByNameCU = findAllByNameCU;
            _findAllBySurenameCU = findAllBySurenameCU;
            _findClientsByAmountCU = findClientsByAmountCU;
        }

        // GET: ClientController
        public ActionResult Index(string mensaje,string nom,string ape)
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                ViewBag.mensaje = mensaje;
                IEnumerable<ClientDTO> listaCli = new List<ClientDTO>();

                if (string.IsNullOrEmpty(nom) && string.IsNullOrEmpty(ape))
                {
                    listaCli = _findAllClientCU.MostrarClientes();
                }
                if (nom == "FiltrarClientesNombre")
                {
                    string pal = (string)TempData["palabra"];
                    listaCli = _findAllByNameCU.ClientesPorNombre(pal);
                }
                if (ape == "FiltrarClientesApellido")
                {
                    string pal = (string)TempData["palAp"];
                    listaCli = _findAllBySurenameCU.EncontrarClientesPorApellido(pal);
                }

                return View(listaCli);
            }
            else 
            {
                return RedirectToAction("Index", "Error");
            }
            
        }

        [HttpPost]
        public ActionResult FiltrarClientesNombre(string palabra) 
        {
            if (string.IsNullOrEmpty(palabra)) 
            {
                return RedirectToAction("Index", new {mensaje = "El nombre no puede estar vacio"});
            }

            TempData["palabra"] = palabra;
            return RedirectToAction("Index",new { nom = "FiltrarClientesNombre" });
        }

        [HttpPost]
        public ActionResult FiltrarClientesApellido(string palAp)
        {
            if (string.IsNullOrEmpty(palAp))
            {
                return RedirectToAction("Index", new { mensaje = "El apellido no puede estar vacio" });
            }

            TempData["palAp"] = palAp;
            return RedirectToAction("Index", new { ape = "FiltrarClientesApellido" });
        }

        [HttpPost]
        public ActionResult FiltrarClientesPorMonto(double monto)
        {
            return View(_findClientsByAmountCU.ClientesQueSuperanMonto(monto));
        }


        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
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

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
