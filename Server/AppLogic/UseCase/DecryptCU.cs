using AppLogic.UseCaseInterface;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase
{
    public class DecryptCU : IDecryptCU
    {
        private IRepositoryUser _repoUser;
        public DecryptCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }

        public string DesencriptarContraseña(string contraseña)
        {
            return _repoUser.Decrypt(contraseña);
        }
    }
}
