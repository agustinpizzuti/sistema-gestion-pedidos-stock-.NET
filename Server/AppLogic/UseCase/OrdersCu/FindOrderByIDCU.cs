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
    public class FindOrderByIDCU : IFindOrderByIDCU
    {
        private IRepositoryOrder _repoOrder;

        public FindOrderByIDCU(IRepositoryOrder repoOrder)
        {
            _repoOrder = repoOrder;
        }

        public OrderDTO OrdenPorID(int id)
        {
            return OrderDTOMapper.ToDto(this._repoOrder.FindByID(id));
        }
    }
}
