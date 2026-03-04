using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.ClientsCU
{
    public interface IFindClientByIDCU
    {
        public ClientDTO ClientePorID(int ID);
    }
}
