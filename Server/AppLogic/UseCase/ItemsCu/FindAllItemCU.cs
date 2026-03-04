using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.ItemsCU;
using AppLogic.UseCaseInterface.UsersCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.ItemsCu
{
    public class FindAllItemCU : IFindAllItemCU
    {
        private IRepositoryItem _repoItem;

        public FindAllItemCU(IRepositoryItem repoItem)
        {
            _repoItem = repoItem;
        }

        public IEnumerable<ItemDTO> TodosLosItems()
        {
            return _repoItem.FindAll().Select(i => ItemDTOMapper.ToDto(i));
        }
    }
}
