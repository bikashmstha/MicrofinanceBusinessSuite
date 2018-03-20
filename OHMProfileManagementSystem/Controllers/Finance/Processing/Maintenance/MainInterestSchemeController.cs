using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class MainInterestSchemeController : ControllerBase
    {
        private static IMainInterestSchemeDao mainInterestSchemeDao = DataAccess.MainInterestSchemeDao;

        public object Get()
        {
            return mainInterestSchemeDao.Get();
        }

        public object Save(MainInterestScheme mainInterestScheme)
        {
            return mainInterestSchemeDao.Save(mainInterestScheme);
        }
        public object Search(MainInterestScheme mainInterestScheme)
        {
            return mainInterestSchemeDao.Search(mainInterestScheme);
        }
    }
}