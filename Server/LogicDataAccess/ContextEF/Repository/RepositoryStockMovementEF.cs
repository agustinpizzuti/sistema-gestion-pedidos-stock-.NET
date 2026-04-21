using BussinesLogic.Entity;
using BussinesLogic.Exceptions.StockMovement;
using BussinesLogic.RepositoryInterface;
using LogicDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDataAccess.ContextEF.Repository
{
    public class RepositoryStockMovementEF : IRepositoryStockMovement
    {
        private PaperFactoryContext _context;

        public RepositoryStockMovementEF() 
        {
            _context = new PaperFactoryContext();
        }

        public bool Add(StockMovement stockMovement)
        {
            try 
            {
                stockMovement.IsValidWithSettings(new RepositorySettingEF(_context));

                this._context.Set<StockMovement>().Add(stockMovement);
                this._context.Entry(stockMovement.item).State = EntityState.Unchanged;
                this._context.Entry(stockMovement.movementType).State = EntityState.Unchanged;

                _context.Add(stockMovement);
                _context.SaveChanges();

                return true;
            } 
            catch (StockMovementException ex )
            {
                throw ex;
            }
        }

        public IEnumerable<StockMovement> FindAll()
        {
            return _context.stocksMovement.Include(movement => movement.item).Include(movement => movement.movementType).ToList();
        }

        public StockMovement FindByID(int id)
        {
            throw new NotImplementedException();
        }

        //public StockMovement

        public IEnumerable<Item> GetItemsByDateOfMovement(DateTime dateOne, DateTime dateTwo,int pag,int size)
        {
            return _context.stocksMovement.Where(movement => movement.dateOfMovement >= dateOne && movement.dateOfMovement <= dateTwo)
                .Select(movement => movement.item).Skip((pag-1)*size).Take(size).ToList();
        }
  
        public IEnumerable<StockMovement> GetStockMovementForItemAndMovementType(int idItem, string type,int pag,int size)
        {
            return _context.stocksMovement.Include(movement => movement.movementType)
                .Include(movement => movement.item)
                .Where(movement => movement.itemID == idItem && movement.movementType.name == type)
                .OrderByDescending(movement => movement.dateOfMovement)
                .ThenBy(movement => movement.amount).Skip((pag - 1) * size).Take(size).ToList();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(StockMovement t)
        {
            throw new NotImplementedException();
        }
    }
}
