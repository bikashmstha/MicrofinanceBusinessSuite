﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class InterestSchemeMasterController : ControllerBase
    {
        private static IInterestSchemeMasterDao interestSchemeMasterDao = DataAccess.InterestSchemeMasterDao;



        public object SaveInterestSchemeMaster(InterestSchemeMaster interestSchemeMaster)
        {
            return interestSchemeMasterDao.SaveInterestSchemeMaster(interestSchemeMaster);
        }
        public object SearchInterestSchemeMaster(InterestSchemeMaster interestSchemeMaster)
        {
            return interestSchemeMasterDao.SearchInterestSchemeMaster(interestSchemeMaster);
        }

        public object GetIntSchemeMasterList(string IntSchemeCode, string IntSchemeDesc, string SchemeFor)
        {
            return interestSchemeMasterDao.GetIntSchemeMasterList(IntSchemeCode, IntSchemeDesc, SchemeFor);
        }

    }
}