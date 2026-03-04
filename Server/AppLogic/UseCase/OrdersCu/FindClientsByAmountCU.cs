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
    public class FindClientsByAmountCU : IFindClientsByAmountCU
    {
        private IRepositoryOrder _repoOrder;

        public FindClientsByAmountCU(IRepositoryOrder repoOrder)
        {
            _repoOrder = repoOrder;
        }
        public IEnumerable<ClientDTO> ClientesQueSuperanMonto(double amount)
        {
            return _repoOrder.FindClientsByAmount(amount).Select(client => ClientDTOMapper.ToDto(client));
        }
    }
}
