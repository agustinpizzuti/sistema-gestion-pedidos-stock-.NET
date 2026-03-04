using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.StockMovementCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.StockMovementCu
{
    public class SummaryAmountForYearCU : ISummaryAmountForYearCU
    {
        private IRepositoryStockMovement _repo;
        public SummaryAmountForYearCU(IRepositoryStockMovement repositoryStockMovement) 
        {
            _repo = repositoryStockMovement;
        }
        public IEnumerable<SummaryDTO> GetSummaryForYear()
        {
            try 
            {
                IEnumerable<StockMovementDTO> stockMovements = this._repo.FindAll().Select(movement => StockMovementDTOMapper.ToDto(movement));

                return stockMovements.GroupBy(movement => movement.dateOfMovement.Year)
                    .Select(move => new SummaryDTO
                    {
                        year = move.First().dateOfMovement.Year, //preguntar como funciona
                        amount = move.Sum(m => m.amount),
                        movements = move.GroupBy(m => m.movementType.name)
                                        .Select(m => new TypeAndAmount
                                        {
                                            typeName = m.First().movementType.name,
                                            amount = m.Sum(m => m.amount)
                                        }).ToList()
                    }).ToList();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
    }
}
