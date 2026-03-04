using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.RepositoryInterface
{
    public interface IRepositoryOrder:IRepository<Order>
    {
        public IEnumerable<Order> OrdenesCanceladas();

        public IEnumerable<Order> OrdenesPorFechaNoEntregado(DateTime fecha);

        public void CambiarEstadoPedido(int id);

        public IEnumerable<Client> FindClientsByAmount(double amount);
    }
}
