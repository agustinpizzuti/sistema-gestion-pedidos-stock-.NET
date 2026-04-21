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
    public class FindTypeByIDCU : IFindTypeByIDCU
    {
        private IRepositoryMovementType _repo;

        public FindTypeByIDCU(IRepositoryMovementType repo)
        {
            _repo = repo;
        }
        public MovementTypeDTO TypeByID(int id)
        {
            return MovementTypeDTOMapper.ToDto(_repo.FindByID(id));
        }
    }
}
