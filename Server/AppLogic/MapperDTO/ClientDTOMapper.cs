using AppLogic.DTOs;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.ClientException;
using BussinesLogic.Exceptions.ItemException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.MapperDTO
{
    public class ClientDTOMapper
    {
        public static ClientDTO ToDto(Client client)
        {
            return new ClientDTO(client);
        }

        public static Client FromDto(ClientDTO dto)
        {
            if (dto == null)
            {
                throw new ClientException();
            }

            return new Client(dto.Id, dto.socialReason,dto.rut,dto.street,dto.number,dto.city,dto.distance,dto.name,dto.surename);
        }
    }
}
