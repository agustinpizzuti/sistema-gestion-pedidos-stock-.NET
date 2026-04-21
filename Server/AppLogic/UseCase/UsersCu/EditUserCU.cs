using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.UsersCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.UsersCu
{
    public class EditUserCU : IEditUserCU
    {
        private IRepositoryUser _repoUser;
        public EditUserCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }

        public void EditarUsuarioCU(UserDTO usuarioDTO)
        {
            this._repoUser.Update(UserDTOMapper.FromDto(usuarioDTO));
        }
    }
}
