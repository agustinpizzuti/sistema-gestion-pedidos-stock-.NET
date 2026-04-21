using AppLogic.DTOs;
using AppLogic.UseCaseInterface.ItemsCU;
using AppLogic.UseCaseInterface.UsersCU;
using BussinesLogic.Exceptions.ItemException;
using BussinesLogic.RepositoryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ItemController : Controller
    {
        private IFindAllItemCU _findAllItem;
        private ICreateItemCU _createItem;

        public ItemController(IFindAllItemCU findAllItemCU,ICreateItemCU createItemCU) 
        {
            _findAllItem = findAllItemCU;
            _createItem = createItemCU;
        }

        // GET: ItemController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                return View(_findAllItem.TodosLosItems());
            }
            else 
            {
                return RedirectToAction("Index", "Error");
            }
            
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create(string mensaje)
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                ViewBag.mensaje = mensaje;
                return View();
            }
            else 
            {
                return RedirectToAction("Index","Error");
            }
            
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemDTO itemDTO)
        {
            try
            {
                _createItem.AgregarItem(itemDTO);
                return RedirectToAction(nameof(Index));
            }
            catch(ItemException ex)
            {
                return RedirectToAction("Create", new { mensaje = ex.Message });
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
    }
}
