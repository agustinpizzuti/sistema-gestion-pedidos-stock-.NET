using AppLogic.DTOs;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.LineException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.MapperDTO
{
    public class LineDTOMapper
    {
        public static LineDTO ToDto(Line line) 
        {
            ItemDTOMapper.ToDto(line.item);
            return new LineDTO(line);
        }

        public static Line FromDto(LineDTO line) 
        {
            if (line == null) 
            { 
                throw new LineException(); 
            }

            return new Line(line.Id,line.idItem,ItemDTOMapper.FromDto(line.item),line.amount);
        }
    }
}
