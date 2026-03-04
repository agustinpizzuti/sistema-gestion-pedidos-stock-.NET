using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.StockMovementCU
{
    public interface IFindAllStockMovementCU
    {
        public IEnumerable<StockMovementDTO> FindAllStockMovement();
    }
}
