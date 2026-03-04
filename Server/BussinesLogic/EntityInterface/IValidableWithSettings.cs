using BussinesLogic.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.EntityInterface
{
    internal interface IValidableWithSettings
    {
        public void IsValidWithSettings(IRepositorySetting repositorySetting);
    }
}
