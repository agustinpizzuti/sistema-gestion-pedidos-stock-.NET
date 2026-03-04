using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.RepositoryInterface
{
    public interface IRepositorySetting
    {
        public double getValueByName(string name);
    }
}
