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
    public class CreateItemCU:ICreateItemCU
    {
        private IRepositoryItem _repoItem;

        public CreateItemCU(IRepositoryItem repoItem)
        {
            _repoItem = repoItem;
        }

        public void AgregarItem(ItemDTO itemDTO)
        {
            this._repoItem.Add(ItemDTOMapper.FromDto(itemDTO));
        }
    }
}
