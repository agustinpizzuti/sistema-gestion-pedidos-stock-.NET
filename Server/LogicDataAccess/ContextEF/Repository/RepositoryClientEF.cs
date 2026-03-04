using BussinesLogic.Entity;
using BussinesLogic.EntityInterface;
using BussinesLogic.Exceptions.ClientException;
using BussinesLogic.RepositoryInterface;
using LogicDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDataAccess.ContextEF.Repository
{
    public class RepositoryClientEF : IRepositoryClient
    {
        private PaperFactoryContext _context;

        public RepositoryClientEF()
        {
            _context = new PaperFactoryContext();
        }

        public bool Add(Client t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> FindAll()
        {
            return _context.clients.ToList();
        }

        public Client FindByID(int id)
        {
            try
            {
                return _context.clients.Where(client => client.Id == id).FirstOrDefault();
            }
            catch (ClientException ex)
            {
                throw new ClientException("No se encontro el cliente");
            }
        }

        public IEnumerable<Client> FindByName(string name)
        {
            return _context.clients.Where(client => client.nombreCli.name.Contains(name)).ToList();
        }

        public Client FindByRut(string rut)
        {
            try 
            {
                return _context.clients.Where(client => client.rut == rut).FirstOrDefault();
            }catch (ClientException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Client> FindBySurename(string surename)
        {
            return _context.clients.Where(client => client.nombreCli.surename.Contains(surename)).ToList();
        }


        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Client t)
        {
            throw new NotImplementedException();
        }
    }
}
