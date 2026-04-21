using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface
{
    public interface IGetUserByEmailCU
    {
        public UserDTO EncontrarUsuarioPorMail(string mail);

    }
}
