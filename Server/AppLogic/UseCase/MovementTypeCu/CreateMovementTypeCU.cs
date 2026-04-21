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
    public class CreateMovementTypeCU : ICreateMovementTypeCU
    {
        private IRepositoryMovementType _repo;

        public CreateMovementTypeCU(IRepositoryMovementType repo)
        {
            _repo = repo;
        }

        public void AddMovementType(MovementTypeDTO movementTypeDto)
        {
            _repo.Add(MovementTypeDTOMapper.FromDto(movementTypeDto));
        }
    }
}
