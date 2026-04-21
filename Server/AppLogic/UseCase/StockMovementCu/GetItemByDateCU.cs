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
    public class GetItemByDateCU : IGetItemByDateCU
    {
        private IRepositoryStockMovement _repo;
        private IRepositorySetting _setting;
        public GetItemByDateCU(IRepositoryStockMovement repo, IRepositorySetting setting)
        {
            _repo = repo;
            _setting = setting;
        }

        public IEnumerable<ItemDTO> ItemsByDate(DateTime dateOne, DateTime dateTwo, int pag)
        {
            int size = int.Parse(_setting.getValueByName("TamPag") + "");
            return _repo.GetItemsByDateOfMovement(dateOne, dateTwo,pag,size).Select(item => ItemDTOMapper.ToDto(item));
        }
    }
}
