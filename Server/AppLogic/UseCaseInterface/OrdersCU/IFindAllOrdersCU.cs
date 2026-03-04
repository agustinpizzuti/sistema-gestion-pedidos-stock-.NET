using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.OrdersCU
{
    public interface IFindAllOrdersCU
    {
        public IEnumerable<OrderDTO> ListarTodosLosPedidos();
    }
}
