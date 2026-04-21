using AppLogic.UseCaseInterface;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase
{
    public class EncryptCU : IEncryptCU
    {
        private IRepositoryUser _repoUser;
        public EncryptCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }

        public string EncriptarContraseña(string contraseña)
        {
            return _repoUser.Encrypt(contraseña);
        }
    }
}
