using AppLogic.DTOs;
using AppLogic.UseCaseInterface.MovementTypeCU;
using AppLogic.UseCaseInterface.StockMovementCU;
using BussinesLogic.Exceptions.ItemException;
using BussinesLogic.Exceptions.MovementType;
using BussinesLogic.Exceptions.StockMovement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/StockMovements")]
    [ApiController]
    public class StockMovementsController : ControllerBase
    {
        private ICreateStockMovementCU _create;
        private IFindAllStockMovementCU _findAll;
        private IGetMovementByItemAndTypeCU _movementByItemAndType;
        
        public StockMovementsController(ICreateStockMovementCU create
            , IFindAllStockMovementCU findAll
            , IGetMovementByItemAndTypeCU getMovementByItemAndTypeCU)
        {
            _create = create;
            _findAll = findAll;
            _movementByItemAndType = getMovementByItemAndTypeCU;
        }

        /// <summary>
        /// Listado de todos los movimientos de stock
        /// </summary>
        /// <returns>Retorna todos los movimientos de stock</returns>
        [HttpGet(Name = "GetAllMovements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<StockMovementDTO>> Get()
        {
            try
            {
                IEnumerable<StockMovementDTO> movements = this._findAll.FindAllStockMovement();

                if (movements.Count() > 0)
                {
                    return Ok(movements);
                }

                return NoContent();
            }
            catch (StockMovementException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creacion de un movimiento de stock
        /// </summary>
        /// <param name="stockMovementDTO">movimiento de stock</param>
        /// <returns>Se devuelve un codigo 201 si se creo el movimiento correctamente</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StockMovementDTO> Create([FromBody] StockMovementDTO stockMovementDTO)
        {
            try
            {
                this._create.CreateStockMovement(stockMovementDTO);
                return Created("api/StockMovements", stockMovementDTO);
            }
            catch (StockMovementException ex)
            {
                return BadRequest(ex.Message);
            }
        }

      

        /// <summary>
        /// Listado de los movimientos de stock por item y tipo de movimiento
        /// </summary>
        /// <param name="idItem">id del item</param>
        /// <param name="type">nombre del tipo de movimiento</param>
        /// <param name="pag">pagina a la que se hace referencia</param>
        /// <returns>Si retorna un codigo 200, lista los movimientos de ese item y ese tipo de movimiento</returns>
        [HttpGet("{idItem}, {type} , {pag}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]     
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<StockMovementDTO>> GetMovements(int idItem, string type, int pag)
        {
            try
            {
                IEnumerable<StockMovementDTO> movements = this._movementByItemAndType.GetMovementByItemAndType(idItem, type, pag);

                if (movements.Count() > 0)
                {
                    return Ok(movements);
                }

                return NoContent();
            }
            catch (StockMovementException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
