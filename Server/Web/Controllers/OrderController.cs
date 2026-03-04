using AppLogic.DTOs;
using AppLogic.UseCaseInterface.ClientsCU;
using AppLogic.UseCaseInterface.ItemsCU;
using AppLogic.UseCaseInterface.OrdersCU;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.LineException;
using BussinesLogic.Exceptions.OrderException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private IFindAllOrdersCU _findAllOrdersCU;
        private ICreateOrderCU _createOrderCU;
        private IFindItemByIDCU _findItemByIDCU;
        private IFindAllClientsCU _findAllClientsCU;
        private IFindAllItemCU _findAllItemCU;
        private IFindClientByIDCU _findClientByIDCU;
        private IFindOrderByIDCU _findOrderByIDCU;
        private ICancelOrderCU _cancelOrderCU;
        private IFindOrderByDateCU _findOrderByDateCU;
        private static OrderDTO tempOrder;

        public OrderController(IFindAllOrdersCU findAllOrdersCU, 
            ICreateOrderCU createOrderCU,
            IFindItemByIDCU findItemByIDCU,
            IFindAllClientsCU findAllClientsCU,
            IFindAllItemCU findAllItemCU,
            IFindClientByIDCU findClientByIDCU,
            IFindOrderByIDCU findOrderByIDCU,
            ICancelOrderCU cancelOrderCU,
            IFindOrderByDateCU findOrderByDateCU)
        {
            _findAllOrdersCU = findAllOrdersCU;
            _createOrderCU = createOrderCU;
            _findItemByIDCU = findItemByIDCU;
            _findAllClientsCU = findAllClientsCU;
            _findAllItemCU = findAllItemCU;
            _findClientByIDCU = findClientByIDCU;
            _findOrderByIDCU = findOrderByIDCU;
            _cancelOrderCU = cancelOrderCU;
            _findOrderByDateCU = findOrderByDateCU;
        }

        // GET: OrderController1
        public ActionResult Index(string mensaje)
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                ViewBag.Mensaje = mensaje;
                return View(_findAllOrdersCU.ListarTodosLosPedidos());
            }
            else 
            {
                return RedirectToAction("Index","Error");
            }
            
        }

        // GET: OrderController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController1/Create
        public ActionResult Create(string mensaje)
        {
            if (HttpContext.Session.GetString("rol") != null && HttpContext.Session.GetString("rol") == "admin")
            {
                ViewBag.mensaje = mensaje;

                ViewBag.clients = new SelectList(_findAllClientsCU.MostrarClientes(), "Id", "socialReason");
                ViewBag.items = new SelectList(_findAllItemCU.TodosLosItems(), "Id", "name");

                if (tempOrder != null)
                {
                    ViewBag.lines = tempOrder.lines;
                }

                return View();
            }
            else 
            {
                return RedirectToAction("Index","Error");
            }
            
        }

        // POST: OrderController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,OrderDTO orderDTO)
        {
            try
            {
                ClientDTO cliente = _findClientByIDCU.ClientePorID(orderDTO.idClient);

                orderDTO.creationDate = DateTime.Now;
                orderDTO.client = cliente;

                int daysGap = (orderDTO.deliveryDate - orderDTO.creationDate).Days;

                if (daysGap <= 5)
                {
                    orderDTO.isExrpress = true;
                }

                if(daysGap >= 6) 
                {
                    orderDTO.isExrpress = false;
                }

                if (tempOrder != null && tempOrder.lines.Count > 0)
                {
                    orderDTO.lines = tempOrder.lines;
                }
                else
                {
                    orderDTO.lines = new List<LineDTO>();
                }

                _createOrderCU.AgregarOrden(orderDTO);

                tempOrder.lines = new List<LineDTO>();

                return RedirectToAction(nameof(Index));
            }
            catch (OrderException ex)
            {
                tempOrder.lines = new List<LineDTO>();
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (LineException lex) 
            {
                tempOrder.lines = new List<LineDTO>();
                return RedirectToAction("Create", new { mensaje = lex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLine(int idItem, int amount) 
        {
            try
            {
                ItemDTO item = _findItemByIDCU.ItemPorID(idItem);

                LineDTO line = new LineDTO
                {
                    idItem = idItem,
                    item = item,
                    amount = amount,
                };
                if (tempOrder == null) 
                {
                    tempOrder = new OrderDTO { lines = new List<LineDTO>()};
                }
                tempOrder.lines.Add(line);
                return RedirectToAction(nameof(Create));
            }
            catch 
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult OrderByDate(DateTime date) 
        {
            return View(_findOrderByDateCU.OrdenesPorFecha(date));  
        }

        public IActionResult CambiarEstadoPedido(int id) 
        {
            try
            {
                _cancelOrderCU.CancelarPedido(id);
                //OrderDTO orden = _findOrderByIDCU.OrdenPorID(id);
                return RedirectToAction(nameof(Index));
            }
            catch(OrderException ex) 
            {
                throw ex;
            }           
        } 

        // GET: OrderController1/Edit/5
        public ActionResult Edit(int id)
        {      
            return View();
        }

        // POST: OrderController1/Edit/5
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

        // GET: OrderController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController1/Delete/5
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
