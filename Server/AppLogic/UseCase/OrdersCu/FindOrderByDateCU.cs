using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.OrdersCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.OrdersCu
{
    public class FindOrderByDateCU : IFindOrderByDateCU
    {
        private IRepositoryOrder _repoOrder;

        public FindOrderByDateCU(IRepositoryOrder repoOrder)
        {
            _repoOrder = repoOrder;
        }

        public IEnumerable<OrderDTO> OrdenesPorFecha(DateTime fechaEmision)
        {
            return this._repoOrder.OrdenesPorFechaNoEntregado(fechaEmision).Select(order => OrderDTOMapper.ToDto(order));
        }
    }
}
