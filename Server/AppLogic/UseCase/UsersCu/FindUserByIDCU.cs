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
    public class FindUserByIDCU : IFindUserByIDCU
    {
        private IRepositoryUser _repoUser;
        public FindUserByIDCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }
        public UserDTO EncontrarUsuarioPorID(int id)
        {
            return UserDTOMapper.ToDto(_repoUser.FindByID(id));
        }
    }
}
