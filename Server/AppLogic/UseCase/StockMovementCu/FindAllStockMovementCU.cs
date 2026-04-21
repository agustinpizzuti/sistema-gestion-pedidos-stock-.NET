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
    public class FindAllStockMovementCU : IFindAllStockMovementCU
    {
        private IRepositoryStockMovement _repo;

        public FindAllStockMovementCU(IRepositoryStockMovement repo)
        {
            _repo = repo;
        }

        public IEnumerable<StockMovementDTO> FindAllStockMovement()
        {
            return _repo.FindAll().Select(stockMovement => StockMovementDTOMapper.ToDto(stockMovement));
        }
    }
}
