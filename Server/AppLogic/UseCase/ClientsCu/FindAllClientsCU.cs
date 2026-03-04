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
    public class FindAllClientsCU : IFindAllClientsCU
    {
        private IRepositoryClient _repoClient;
        public FindAllClientsCU(IRepositoryClient repositoryClient)
        {
            _repoClient = repositoryClient;
        }

        public IEnumerable<ClientDTO> MostrarClientes()
        {
            return _repoClient.FindAll().Select(c => ClientDTOMapper.ToDto(c));
        }
    }
}
