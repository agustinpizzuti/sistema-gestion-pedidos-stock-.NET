using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.RepositoryInterface
{
    public interface IRepositoryItem:IRepository<Item>
    {
        public Item FindByCode(string code);

        public Item FindByName(string name);
    }
}
