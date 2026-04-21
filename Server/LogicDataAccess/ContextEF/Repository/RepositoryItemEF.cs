using BussinesLogic.Entity;
using BussinesLogic.Exceptions.ItemException;
using BussinesLogic.RepositoryInterface;
using LogicDataAccess.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDataAccess.ContextEF.Repository
{
    public class RepositoryItemEF :IRepositoryItem
    {
        private PaperFactoryContext _context;

        public RepositoryItemEF()
        {
            _context = new PaperFactoryContext();
        }

        public bool Add(Item itemToAdd)
        {
            try
            {
                Item itemCode = this.FindByCode(itemToAdd.code);
                Item itemName = this.FindByName(itemToAdd.name);

                if (itemName == null)
                {
                    if (itemCode == null)
                    {
                        itemToAdd.IsValidWithSettings(new RepositorySettingEF(_context));
                        _context.Add(itemToAdd);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new ItemException("El codigo ingresado pertenece a otro item");
                    }
                }
                else
                {
                    throw new ItemException("El nombre ingresado pertenece a otro item");
                }

            }
            catch (ItemException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Item> FindAll()
        {
            return _context.items.OrderBy(item => item.name).ToList();
        }

        public Item FindByCode(string code)
        {
            try 
            {
                return _context.items.Where(item => item.code == code).FirstOrDefault();
            }catch (ItemException ex) 
            {
                throw ex;
            }
        }

        public Item FindByID(int id)
        {
            return _context.items.Where(item => item.Id == id).FirstOrDefault();
        }

        public Item FindByName(string name)
        {
            try 
            {
                return _context.items.Where(item => item.name == name).FirstOrDefault();
            } 
            catch (ItemException ex) 
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Item t)
        {
            throw new NotImplementedException();
        }
    }
}
