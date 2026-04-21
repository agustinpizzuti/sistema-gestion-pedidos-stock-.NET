using AppLogic.DTOs;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.ItemException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.MapperDTO
{
    public class ItemDTOMapper
    {
        public static ItemDTO ToDto(Item item)
        {
            return new ItemDTO(item);
        }

        public static Item FromDto(ItemDTO dto)
        {
            if (dto == null)
            {
                throw new ItemException();
            }

            return new Item(dto.Id, dto.name, dto.description,dto.code, dto.price);
        }
    }
}
