using AppLogic.DTOs;
using AppLogic.UseCase.ItemsCu;
using AppLogic.UseCaseInterface.ItemsCU;
using AppLogic.UseCaseInterface.OrdersCU;
using BussinesLogic.Exceptions.ItemException;
using BussinesLogic.Exceptions.OrderException;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/Orders")]
    public class OrdersController : Controller
    {
        private IFindCanceledOrdersCU _findCanceledOrdersCU;

        public OrdersController(IFindCanceledOrdersCU findCanceledOrdersCU)
        {
            _findCanceledOrdersCU = findCanceledOrdersCU;
        }

        /// <summary>
        /// Listado de ordenes canceladas
        /// </summary>
        /// <returns>Retorna todas las ordenes canceladas y ordenadas por fecha de creacion descendente</returns>
        [HttpGet(Name = "GetOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<OrderDTO>> Get()
        {
            try
            {

                IEnumerable<OrderDTO> orders = _findCanceledOrdersCU.PedidosCancelados();

                if (orders.Count() > 0)
                {
                    return Ok(orders);
                }

                return NoContent();
            }
            catch (OrderException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
