using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Menu
{
    public class ModuleController : ControllerBase
    {
        private static IModuleDao moduleDao = DataAccess.ModuleDao;

        public object Get()
        {
            return moduleDao.Get();
        }

        public object Save(Module module)
        {
            return moduleDao.Save(module);
        }
        public object Search(Module module)
        {
            return moduleDao.Search(module);
        }

        public object GetModuleShort()
        {
            return moduleDao.GetModuleShort();
        }
    }
}