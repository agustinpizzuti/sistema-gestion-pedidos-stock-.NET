using AppLogic.DTOs;
using AppLogic.MapperDTO;
using AppLogic.UseCaseInterface.ItemsCU;
using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCase.ItemsCu
{
    public class FindItemByIDCU : IFindItemByIDCU
    {
        private IRepositoryItem _repoItem;

        public FindItemByIDCU(IRepositoryItem repoItem)
        {
            _repoItem = repoItem;
        }

        public ItemDTO ItemPorID(int id)
        {
            return ItemDTOMapper.ToDto(_repoItem.FindByID(id));
        }
    }
}
