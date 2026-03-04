using BussinesLogic.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogic.MapperDTO;

namespace AppLogic.DTOs
{
    public class LineDTO
    {
        public int Id { get; set; }
        public int idItem { get; set; }  
        public ItemDTO item { get; set; }
        public int amount { get; set; }
        public double price { get; set; }


        public LineDTO() { }
        public LineDTO(Line line) 
        {
            if (line != null) 
            {
                this.Id = line.Id;
                this.idItem=line.idItem;
                this.item=ItemDTOMapper.ToDto(line.item);
                this.amount = line.amount;
                this.price = line.price;
            }
        }

    }
}
