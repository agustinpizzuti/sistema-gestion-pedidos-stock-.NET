using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.StockMovementCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.StockMovementCu
{
    public class GetMovementByItemAndTypeCU : IGetMovementByItemAndTypeCU
    {
        private IRepositoryStockMovement _repo;
        private IRepositorySetting _setting;

        public GetMovementByItemAndTypeCU(IRepositoryStockMovement repo, IRepositorySetting setting)
        {
            _repo = repo;
            _setting = setting;
        }
        public IEnumerable<StockMovementDTO> GetMovementByItemAndType(int idItem, string type,int pag)
        {
            int size = int.Parse(_setting.getValueByName("TamPag") + "");
            return _repo.GetStockMovementForItemAndMovementType(idItem, type,pag,size).Select(move =>StockMovementDTOMapper.ToDto(move));
        }
    }
}
