using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class InterestSchemeController : ControllerBase
    {
        private static IInterestSchemeDao interestSchemeDao = DataAccess.InterestSchemeDao;



        public object SaveInterestScheme(InterestScheme interestScheme)
        {
            return interestSchemeDao.SaveInterestScheme(interestScheme);
        }
        public object SearchInterestScheme(InterestScheme interestScheme)
        {
            return interestSchemeDao.SearchInterestScheme(interestScheme);
        }

        public object GetInterestScheme(string IntSchemeDesc)
        {
            return interestSchemeDao.GetInterestScheme(IntSchemeDesc);
        }

    }
}