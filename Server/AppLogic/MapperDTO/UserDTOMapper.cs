using AppLogic.DTOs;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.UserException;
using BussinesLogic.ValueObject.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.MapperDTO
{
    public class UserDTOMapper
    {
        public static UserDTO ToDto(User usuario)
        {
            return new UserDTO(usuario);
        }

        public static User FromDto(UserDTO dto)
        {
           
            if (dto == null)
            {
                throw new UserException();
            }

            if (dto.isAdmin)
            {
                return new Admin(dto.Id, dto.mail, dto.name, dto.surename, dto.pass, dto.encrypt, dto.isAdmin, dto.isManager);
            }
            else 
            {
                return new Manager(dto.Id, dto.mail, dto.name, dto.surename, dto.pass, dto.encrypt, dto.isAdmin, dto.isManager);
            }

            
        }
    }
}
