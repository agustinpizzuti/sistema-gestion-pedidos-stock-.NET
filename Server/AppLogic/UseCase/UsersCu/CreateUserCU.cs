using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.UsersCU;
using BussinesLogic.Entity;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.UsersCu
{
    public class CreateUserCU : ICreateUserCU
    {
        private IRepositoryUser _repoUser;
        public CreateUserCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }
        public void AgregarUsuarioCU(UserDTO userDTO)
        {
            this._repoUser.Add(UserDTOMapper.FromDto(userDTO));
        }
        
    }
}
