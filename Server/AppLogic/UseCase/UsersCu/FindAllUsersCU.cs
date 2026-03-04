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
    public class FindAllUsersCU : IFindAllUsersCU
    {
        private IRepositoryUser _repoUser;
        public FindAllUsersCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }

        public IEnumerable<UserDTO> TodosLosUsuarios()
        {   
            return _repoUser.FindAll().Select(user => UserDTOMapper.ToDto(user));
        }
    }
}
