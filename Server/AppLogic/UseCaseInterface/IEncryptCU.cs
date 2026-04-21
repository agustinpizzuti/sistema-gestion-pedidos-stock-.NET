using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface
{
    public interface IEncryptCU
    {
        public string EncriptarContraseña(string contraseña);
    }
}
