using AppLogic.DTOs;
using AppLogic.UseCaseInterface.MovementTypeCU;
using AppLogic.UseCaseInterface.StockMovementCU;
using BussinesLogic.Exceptions.MovementType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/MovementTypes")]
    public class MovementTypesController : Controller
    {
        private ICreateMovementTypeCU _create;
        private IDeleteMovementTypeCU _delete;
        private IFindAllMovementTypeCU _findAll;
        private IEditMovementTypeCU _edit;
        private IFindTypeByIDCU _findById;
        private IFindAllStockMovementCU _stockMovements;
        public MovementTypesController(
            ICreateMovementTypeCU createMovementTypeCU,
            IDeleteMovementTypeCU deleteMovementTypeCU,
            IFindAllMovementTypeCU findAllMovementTypeCU,
            IEditMovementTypeCU editMovementTypeCU,
            IFindTypeByIDCU findTypeByIDCU,
            IFindAllStockMovementCU findAllStockMovementCU) 
        {
            _create = createMovementTypeCU;
            _delete = deleteMovementTypeCU;
            _findAll = findAllMovementTypeCU;
            _edit = editMovementTypeCU;
            _findById = findTypeByIDCU;
            _stockMovements = findAllStockMovementCU;
        }

        /// <summary>
        /// Muestra todos los tipos de movimientos 
        /// </summary>
        /// <returns>Lista de todos los tipos de movimiento</returns>      
        [HttpGet(Name = "GetAllTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<MovementTypeDTO>> Get()
        {
            try 
            {
                IEnumerable<MovementTypeDTO> movementTypes = this._findAll.AllMovementType();

                if (movementTypes.Count() > 0) 
                {
                    return Ok(movementTypes);
                }

                return NoContent();
            }
            catch (MovementTypeException  ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Opcion para crear un nuevo tipo de movimiento
        /// </summary>
        /// <param name="movementTypeDTO">tipo de movimiento</param>
        /// <returns>Agrega el nuevo tipo de movimiento a la base de datos</returns>
        [HttpPost(Name = "Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovementTypeDTO> Create([FromBody] MovementTypeDTO movementTypeDTO)
        {
            try
            {
                this._create.AddMovementType(movementTypeDTO);
                return Created("api/MovementTypes", movementTypeDTO);
            }
            catch (MovementTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Elimina el tipo de movimiento
        /// </summary>
        /// <param name="Id">id del tipo de movimiento</param>
        /// <returns>Retorna un codigo 200 y elimina el tipo de movimiento</returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovementTypeDTO> Delete(int Id)
        {
            try
            {
                IEnumerable<StockMovementDTO> movementDTOs = this._stockMovements.FindAllStockMovement();     

                foreach (StockMovementDTO m in movementDTOs)
                {
                    if (m.movementType.Id == Id)
                    {
                        return BadRequest();
                    }
                }

                this._delete.DeleteMovementType(Id);
                return Ok();
            }
            catch (MovementTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Actualiza un tipo de movimiento
        /// </summary>
        /// <param name="movementTypeDTO">tipo de movimiento</param>
        /// <returns>Retorna un codigo 200 y actualiza el tipo de movimiento</returns>
        [HttpPut("{MovementTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovementTypeDTO> Update(int MovementTypeId, [FromBody] MovementTypeDTO movementTypeDTO)
        {
            try
            {
                movementTypeDTO.Id = MovementTypeId;

                this._edit.UpdateMovement(movementTypeDTO);

                return Ok(movementTypeDTO);
            }
            catch (MovementTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Recibe un id de un tipo de movimiento y lo retorna
        /// </summary>
        /// <param name="id">id del tipo de movimiento</param>
        /// <returns>Retorna el tipo de movimiento</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovementTypeDTO> GetByID(int id)
        {
            try
            {
                MovementTypeDTO type = this._findById.TypeByID(id);

                if (type.name != null) 
                {
                    return Ok(type);
                }
                return NoContent();
            }
            catch (MovementTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


    }
}
