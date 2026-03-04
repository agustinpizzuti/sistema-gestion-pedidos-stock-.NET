using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.UsersCU
{
    public interface IEditUserCU
    {
        public void EditarUsuarioCU(UserDTO usuarioDTO);
    }
}
