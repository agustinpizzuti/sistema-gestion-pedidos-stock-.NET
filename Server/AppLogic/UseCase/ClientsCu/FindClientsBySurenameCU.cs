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
    public class FindClientsBySurenameCU : IFindClientsBySurenameCU
    {
        private IRepositoryClient _repoClient;

        public FindClientsBySurenameCU(IRepositoryClient repositoryClient)
        {
            _repoClient = repositoryClient;
        }
        public IEnumerable<ClientDTO> EncontrarClientesPorApellido(string apellido)
        {
            return _repoClient.FindBySurename(apellido).Select(c => ClientDTOMapper.ToDto(c));
        }
    }
}
