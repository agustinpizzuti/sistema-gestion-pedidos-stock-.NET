using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.RepositoryInterface
{
    public interface IRepositoryClient:IRepository<Client>
    {
        public IEnumerable<Client> FindByName(string name);

        public IEnumerable<Client> FindBySurename(string surename);

        public Client FindByRut(string rut);
    }
}
