using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.MovementTypeCU
{
    public interface IFindTypeByIDCU
    {
        public MovementTypeDTO TypeByID(int id);
    }
}
