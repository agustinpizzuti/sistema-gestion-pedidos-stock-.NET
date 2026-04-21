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
    public class EditMovementTypeCU:IEditMovementTypeCU
    {
        private IRepositoryMovementType _repo;

        public EditMovementTypeCU(IRepositoryMovementType repo)
        {
            _repo = repo;
        }

        public void UpdateMovement(MovementTypeDTO movementTypeDto)
        {
            _repo.Update(MovementTypeDTOMapper.FromDto(movementTypeDto));
        }
    }
}
