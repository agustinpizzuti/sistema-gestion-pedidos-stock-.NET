using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.MovementTypeCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.MovementTypeCu
{
    public class FindAllMovementTypeCU:IFindAllMovementTypeCU
    {
        private IRepositoryMovementType _repo;

        public FindAllMovementTypeCU(IRepositoryMovementType repo)
        {
            _repo = repo;
        }

        public IEnumerable<MovementTypeDTO> AllMovementType()
        {
            return _repo.FindAll().Select(movementType => MovementTypeDTOMapper.ToDto(movementType));
        }
    }
}
