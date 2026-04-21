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
    public class FindAllOrdersCU : IFindAllOrdersCU
    {
        private IRepositoryOrder _repoOrder;

        public FindAllOrdersCU(IRepositoryOrder repoOrder)
        {
            _repoOrder = repoOrder;
        }

        public IEnumerable<OrderDTO> ListarTodosLosPedidos()
        {
            return _repoOrder.FindAll().Select(order => OrderDTOMapper.ToDto(order));
        }
    }
}
