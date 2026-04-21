using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCaseInterface.ItemsCU
{
    public interface ICreateItemCU
    {
        public void AgregarItem(ItemDTO itemDTO);
    }
}
