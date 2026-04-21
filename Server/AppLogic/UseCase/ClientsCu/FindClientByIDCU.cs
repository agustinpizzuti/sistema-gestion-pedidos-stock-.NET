using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.ClientsCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.ClientsCu
{
    public class FindClientByIDCU:IFindClientByIDCU
    {
        private IRepositoryClient _repoClient;
        public FindClientByIDCU(IRepositoryClient repositoryClient)
        {
            _repoClient = repositoryClient;
        }

        public ClientDTO ClientePorID(int ID)
        {
            return ClientDTOMapper.ToDto(_repoClient.FindByID(ID));
        }
    }
}
