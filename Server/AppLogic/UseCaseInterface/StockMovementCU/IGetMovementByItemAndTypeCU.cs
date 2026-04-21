using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.StockMovementCU
{
    public interface IGetMovementByItemAndTypeCU
    {
        public IEnumerable<StockMovementDTO> GetMovementByItemAndType(int idItem, string type, int pag);
    }
}
