using AppLogic.DTOs;
using AppLogic.UseCaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase
{
    public class LoginCU : ILoginCU
    {
        private IGetUserByEmailCU _getUserByEmailCU;
        private IDecryptCU _decryptCU;
        
        public LoginCU(IGetUserByEmailCU getUserByEmailCU,IDecryptCU decryptCU) 
        {
            this._getUserByEmailCU = getUserByEmailCU;
            this._decryptCU = decryptCU;
            
        }

        public bool Login(string username, string pass)
        {
            UserDTO user = _getUserByEmailCU.EncontrarUsuarioPorMail(username);     

            if (user.mail == null) { return false; }

            return _decryptCU.DesencriptarContraseña(user.encrypt) == pass ; 
        }
    }
}
