using AppLogic.MapperDTO;
using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class StockMovementDTO
    {
        public int Id { get; set; }
        public DateTime dateOfMovement { get; set; }
        public int itemID { get; set; }
        public ItemDTO item { get; set; }
        public string mailUser { get; set; }
        public int movementTypeID { get; set; }
        public MovementTypeDTO movementType { get; set; }
        public int amount { get; set; }

        public StockMovementDTO() { }

        public StockMovementDTO(StockMovement stockMovement)
        {
            if (stockMovement != null) 
            {
                this.Id = stockMovement.Id;
                this.dateOfMovement = stockMovement.dateOfMovement;
                this.itemID = stockMovement.itemID;
                this.item = ItemDTOMapper.ToDto(stockMovement.item);
                this.mailUser = stockMovement.mailUser;
                this.movementTypeID = stockMovement.movementTypeID;
                this.movementType = MovementTypeDTOMapper.ToDto(stockMovement.movementType);
                this.amount = stockMovement.amount;
            }
        }

    }
}
