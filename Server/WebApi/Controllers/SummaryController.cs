using AppLogic.DTOs;
using AppLogic.UseCaseInterface.StockMovementCU;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Summary")]
    [ApiController]
    public class SummaryController:ControllerBase
    {
        private ISummaryAmountForYearCU _summary;

        public SummaryController(ISummaryAmountForYearCU summary)
        {
            _summary = summary;
        }

        /// <summary>
        /// Lista los movimientos de stock agrupandolos por año y por tipo de movimiento
        /// </summary>
        /// <returns>Lista los movimientos</returns>
        [HttpGet(Name = "GetAllSummarys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<SummaryDTO>> GetSummary()
        {
            try
            {
                IEnumerable<SummaryDTO> summarys = this._summary.GetSummaryForYear();

                if (summarys.Count() > 0)
                {
                    return Ok(summarys);
                }

                return NoContent();
            }      
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
