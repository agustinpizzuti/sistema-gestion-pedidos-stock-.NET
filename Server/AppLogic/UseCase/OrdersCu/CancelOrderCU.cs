using AppLogic.UseCaseInterface.OrdersCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.OrdersCu
{
    public class CancelOrderCU: ICancelOrderCU
    {
        private IRepositoryOrder _repoOrder;

        public CancelOrderCU(IRepositoryOrder repoOrder)
        {
            _repoOrder = repoOrder;
        }

        public void CancelarPedido(int id)
        {
            this._repoOrder.CambiarEstadoPedido(id);
        }
    }
}
