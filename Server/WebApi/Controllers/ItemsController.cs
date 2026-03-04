using AppLogic.DTOs;
using AppLogic.UseCaseInterface.ItemsCU;
using AppLogic.UseCaseInterface.StockMovementCU;
using BussinesLogic.Exceptions.ItemException;
using BussinesLogic.Exceptions.MovementType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/Items")]
    public class ItemsController : ControllerBase
    {
        private IFindAllItemCU _findAllItemCU;
        private IFindItemByIDCU _itemByID;
        private IGetItemByDateCU _itemByDate;


        public ItemsController(IFindAllItemCU findAllItemCU, IFindItemByIDCU itemByID, IGetItemByDateCU itemByDate)
        {
            _findAllItemCU = findAllItemCU;
            _itemByID = itemByID;
            _itemByDate = itemByDate;
        }

        /// <summary>
        /// Listado de todos los items
        /// </summary>
        /// <returns>Retorna todos los items ordenados por nombre</returns>
        [HttpGet(Name = "GetItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ItemDTO>> Get() 
        {
            try 
            {
                IEnumerable<ItemDTO> items = _findAllItemCU.TodosLosItems();

                if (items.Count() > 0) 
                {
                    return Ok(items);
                }

                return NoContent();              
            } 
            catch(ItemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Item por id
        /// </summary>
        /// <param name="id">id del item</param>
        /// <returns>Retorna un item dado un id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ItemDTO> GetByID(int id)
        {
            try
            {
                ItemDTO item = this._itemByID.ItemPorID(id);

                if (item.name != null)
                {
                    return Ok(item);
                }

                return NoContent();
            }
            catch (ItemException ex)
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// Listado de items que fueron movidos entre dos fechas
        /// </summary>
        /// <param name="dateOne">primer fecha</param>
        /// <param name="dateTwo">segunda fecha</param>
        /// <param name="pag">pagina a la que se le hace referencia</param>
        /// <returns>
        /// Retorna un codigo 200 y lista los items que fueron movidos entre las dos fechas 
        /// </returns>

        [HttpGet("{dateOne}, {dateTwo} , {pag}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ItemDTO>> GetItems(DateTime dateOne, DateTime dateTwo, int pag)
        {
            try
            {
                IEnumerable<ItemDTO> items = this._itemByDate.ItemsByDate(dateOne, dateTwo, pag);

                if (items.Count() > 0)
                {
                    return Ok(items);
                }

                return NoContent();
            }
            catch (ItemException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
