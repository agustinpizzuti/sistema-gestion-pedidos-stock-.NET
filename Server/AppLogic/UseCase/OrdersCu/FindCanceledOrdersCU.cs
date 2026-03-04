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
    public class FindCanceledOrdersCU: IFindCanceledOrdersCU
    {
        private IRepositoryOrder _repoOrder;

        public FindCanceledOrdersCU(IRepositoryOrder repoOrder)
        {
            _repoOrder = repoOrder;
        }

        public IEnumerable<OrderDTO> PedidosCancelados()
        {
            return _repoOrder.OrdenesCanceladas().Select(order => OrderDTOMapper.ToDto(order));
        }
    }
}
