using BussinesLogic.RepositoryInterface;
using LogicDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDataAccess.ContextEF.Repository
{
    public class RepositorySettingEF : IRepositorySetting
    {
        private PaperFactoryContext _context;
        public RepositorySettingEF()
        {
            _context = new PaperFactoryContext();
        }
        public double getValueByName(string name)
        {
            return _context.settings.Where(setting => setting.settingName == name).FirstOrDefault().settingValue;
        }
    }
}
