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
    public class FindClientsByNameCU:IFindClientsByNameCU
    {
        private IRepositoryClient _repoClient;

        public FindClientsByNameCU(IRepositoryClient repositoryClient)
        {
            _repoClient = repositoryClient;
        }

        public IEnumerable<ClientDTO> ClientesPorNombre(string nombre)
        {
            return _repoClient.FindByName(nombre).Select(c => ClientDTOMapper.ToDto(c));
        }
    }
}
