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
    public class CreateOrderCU : ICreateOrderCU
    {
        private IRepositoryOrder _repoOrder;

        public CreateOrderCU(IRepositoryOrder repoOrder)
        {
            _repoOrder = repoOrder;
        }

        public void AgregarOrden(OrderDTO orderDTO)
        {
            this._repoOrder.Add(OrderDTOMapper.FromDto(orderDTO));
        }
    }
}
