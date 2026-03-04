using AppLogic.DTOs;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.StockMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.MapperDTO
{
    public class StockMovementDTOMapper
    {
        public static StockMovementDTO ToDto(StockMovement stockMovement) 
        {
            return new StockMovementDTO(stockMovement);
        }

        public static StockMovement FromDto(StockMovementDTO dto) 
        {
            if (dto == null) throw new StockMovementException();

            return new StockMovement(dto.Id,dto.dateOfMovement,dto.itemID,ItemDTOMapper.FromDto(dto.item),dto.mailUser,dto.movementTypeID,MovementTypeDTOMapper.FromDto(dto.movementType),dto.amount);
        }
    }
}
