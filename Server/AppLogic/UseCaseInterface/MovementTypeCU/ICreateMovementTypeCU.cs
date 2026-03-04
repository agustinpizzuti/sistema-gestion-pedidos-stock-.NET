using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.MovementTypeCU
{
    public interface ICreateMovementTypeCU
    {
        public void AddMovementType(MovementTypeDTO movementTypeDto);
    }
}
