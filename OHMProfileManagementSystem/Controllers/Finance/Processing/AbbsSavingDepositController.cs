using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class AbbsSavingDepositController : ControllerBase
    {
        private static IAbbsSavingDepositDao abbsSavingDepositDao = DataAccess.AbbsSavingDepositDao;



        public object SaveAbbsSavingDeposit(AbbsSavingDeposit abbsSavingDeposit)
        {
            return abbsSavingDepositDao.SaveAbbsSavingDeposit(abbsSavingDeposit);
        }
        public object SearchAbbsSavingDeposit(AbbsSavingDeposit abbsSavingDeposit)
        {
            return abbsSavingDepositDao.SearchAbbsSavingDeposit(abbsSavingDeposit);
        }

        public object GetAbbsSavingDeposit(string OfficeCode)
        {
            return abbsSavingDepositDao.GetAbbsSavingDeposit(OfficeCode);
        }

    }
}