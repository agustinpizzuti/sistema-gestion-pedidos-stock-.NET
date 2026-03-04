using AppLogic.DTOs;
using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.MovementTypeCU
{
    public interface IFindAllMovementTypeCU
    {
        public IEnumerable<MovementTypeDTO> AllMovementType();
    }
}
