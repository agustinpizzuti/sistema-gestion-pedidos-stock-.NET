using AppLogic.DTOs;
using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.ClientsCU
{
    public interface IFindAllClientsCU
    {
        public IEnumerable<ClientDTO> MostrarClientes();
    }
}
