using BussinesLogic.Entity;
using BussinesLogic.Exceptions.OrderException;
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
    public class RepositoryOrderEF : IRepositoryOrder
    {
        private PaperFactoryContext _context;

        public RepositoryOrderEF()
        {
            _context = new PaperFactoryContext();
        }

        public bool Add(Order orderToAdd)
        {
            try
            { 
                orderToAdd.IsValidWithSettings(new RepositorySettingEF(_context));
                //orderToAdd.IsValid();
                orderToAdd.AsignPrice(new RepositorySettingEF(_context));

                //para que no cree un cliente y un item cada vez que se hace un add de ordenes
                this._context.Set<Order>().Add(orderToAdd);
                this._context.Entry(orderToAdd.client).State = EntityState.Unchanged;
                
                foreach (Line l in orderToAdd.lines) 
                {
                    l.IsValid();
                    this._context.Entry(l.item).State= EntityState.Unchanged;
                }

                _context.orders.Add(orderToAdd);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void CambiarEstadoPedido(int id)
        {
            try
            {

                Order pedidoACancelar = this.FindByID(id);

                if (!pedidoACancelar.cancel) 
                {
                    pedidoACancelar.cancel = true;
                }

                _context.SaveChanges();

            }
            catch (OrderException ex) 
            {
                throw ex;
            }
        }

        public IEnumerable<Order> FindAll()
        {
            return _context.orders.Include(order => order.client).Include(order => order.lines).ThenInclude(line => line.item).ToList();
        } 

        public Order FindByID(int id)
        {
            return _context.orders.Where(order => order.Id == id).Include(order => order.client).Include(order => order.lines).ThenInclude(line =>line.item).FirstOrDefault();
        }

        public IEnumerable<Client> FindClientsByAmount(double amount)
        {
            return _context.orders.Include(order => order.client).Where(order => order.finalPrice > amount).Select(order => order.client).ToList();
        }

        public IEnumerable<Order> OrdenesCanceladas()
        { 
            return _context.orders.Where(order => order.cancel == true).Include(order => order.client).Include(order => order.lines).ThenInclude(line => line.item).OrderByDescending(order => order.creationDate).ToList();
        }

        public IEnumerable<Order> OrdenesPorFechaNoEntregado(DateTime fecha)
        {
            return _context.orders.Where(order => order.cancel ==false && order.creationDate.Day == fecha.Day && order.creationDate.Month == fecha.Month && order.creationDate.Year == fecha.Year && order.delivered == false).Include(order => order.client).Include(order => order.lines).ThenInclude(line => line.item).ToList();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
