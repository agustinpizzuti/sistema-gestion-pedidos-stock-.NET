using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.RepositoryInterface
{
    public interface IRepositoryStockMovement:IRepository<StockMovement>
    {
        public IEnumerable<StockMovement> GetStockMovementForItemAndMovementType(int idItem, string type, int pag, int size);

        public IEnumerable<Item> GetItemsByDateOfMovement(DateTime dateOne, DateTime dateTwo, int pag, int size);
    }
}
