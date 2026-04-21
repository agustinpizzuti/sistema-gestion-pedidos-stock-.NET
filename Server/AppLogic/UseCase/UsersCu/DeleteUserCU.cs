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
    public class DeleteUserCU : IDeleteUserCU
    {
        private IRepositoryUser _repoUser;
        public DeleteUserCU(IRepositoryUser repositoryUser)
        {
            _repoUser = repositoryUser;
        }

        public void EliminarUserCU(int id)
        {
            this._repoUser.Remove(id);
        }
    }
}
