using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.MovementTypeCU;
using AppLogic.UseCaseInterface.StockMovementCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.StockMovementCu
{
    public class CreateStockMovementCU:ICreateStockMovementCU
    {
        private IRepositoryStockMovement _repo;

        public CreateStockMovementCU(IRepositoryStockMovement repo)
        {
            _repo = repo;
        }

        public void CreateStockMovement(StockMovementDTO stockMovementDto)
        {
            _repo.Add(StockMovementDTOMapper.FromDto(stockMovementDto));
        }
    }
}
