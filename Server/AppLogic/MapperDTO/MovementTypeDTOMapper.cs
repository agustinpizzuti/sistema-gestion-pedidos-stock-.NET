using AppLogic.DTOs;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.MovementType;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.MapperDTO
{
    public class MovementTypeDTOMapper
    {
        public static MovementTypeDTO ToDto(MovementType movementType) 
        {
            return new MovementTypeDTO(movementType);
        }

        public static MovementType FromDto(MovementTypeDTO dto) 
        {
            if (dto == null) { throw new MovementTypeException(); }

            return new MovementType(dto.Id, dto.name,dto.sumOrSubstract);
        }
    }
}
