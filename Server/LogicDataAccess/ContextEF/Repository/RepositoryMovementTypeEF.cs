using BussinesLogic.Entity;
using BussinesLogic.Exceptions.MovementType;
using BussinesLogic.Exceptions.UserException;
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
    public class RepositoryMovementTypeEF : IRepositoryMovementType
    {
        private PaperFactoryContext _context;

        public RepositoryMovementTypeEF() 
        {
            _context = new PaperFactoryContext();
        }

        public bool Add(MovementType movementType)
        {
            try 
            {
                movementType.IsValid();
                _context.Add(movementType);
                _context.SaveChanges();

                return true;
            }
            catch (MovementTypeException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<MovementType> FindAll()
        {
            return _context.movementsType.ToList();
        }

        public MovementType FindByID(int id)
        {
            try 
            {
                return _context.movementsType.Where(movementType => movementType.Id == id).FirstOrDefault();
            } 
            catch (MovementTypeException ex)
            { 
                throw ex; 
            }
        }

        public bool Remove(int id)
        {
            try
            {
                MovementType movementType = FindByID(id);
                _context.movementsType.Remove(movementType);
                _context.SaveChanges();

                return true;
            }
            catch (MovementTypeException ex)
            {
                throw ex;
            }
        }

        public bool Update(MovementType movementType)
        {
            try
            {
                movementType.IsValid();
                _context.movementsType.Update(movementType);
                _context.SaveChanges();

                return true;

            }
            catch (MovementTypeException ex)
            {
                throw ex;
            }          
        }
    }
}
