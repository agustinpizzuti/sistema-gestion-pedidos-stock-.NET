using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase
{
    public class GetUserByEmailCU : IGetUserByEmailCU
    {
        private IRepositoryUser _repoUser;
        public GetUserByEmailCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }

        public UserDTO EncontrarUsuarioPorMail(string mail)
        {
            return UserDTOMapper.ToDto(_repoUser.FindByMail(mail));
        }
    }
}
