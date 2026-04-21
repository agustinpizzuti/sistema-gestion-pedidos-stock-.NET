using AppLogic.UseCaseInterface.MovementTypeCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.MovementTypeCu
{
    public class DeleteMovementTypeCU:IDeleteMovementTypeCU
    {
        private IRepositoryMovementType _repo;

        public DeleteMovementTypeCU(IRepositoryMovementType repo)
        {
            _repo = repo;
        }

        public void DeleteMovementType(int id)
        {
            _repo.Remove(id);
        }
    }
}
