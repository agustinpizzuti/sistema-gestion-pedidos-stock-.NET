using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class MovementTypeDTO
    {
        public int Id { get; set; }
        public string name { get; set; }

        public int sumOrSubstract { get; set; }

        public MovementTypeDTO() { }

        public MovementTypeDTO(MovementType movementType)
        {
            if (movementType != null) 
            {
                this.Id = movementType.Id;
                this.name = movementType.name;
                this.sumOrSubstract = movementType.sumOrSubstractStock;
            }
        }
    }
}
