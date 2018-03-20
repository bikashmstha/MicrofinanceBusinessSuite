using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class AbbsSavingWithdrawlController : ControllerBase
    {
        private static IAbbsSavingWithdrawlDao abbsSavingWithdrawlDao = DataAccess.AbbsSavingWithdrawlDao;



        public object SaveAbbsSavingWithdrawl(AbbsSavingWithdrawl abbsSavingWithdrawl)
        {
            return abbsSavingWithdrawlDao.SaveAbbsSavingWithdrawl(abbsSavingWithdrawl);
        }
        public object SearchAbbsSavingWithdrawl(AbbsSavingWithdrawl abbsSavingWithdrawl)
        {
            return abbsSavingWithdrawlDao.SearchAbbsSavingWithdrawl(abbsSavingWithdrawl);
        }

        public object GetAbbsSavingWithdrawal(string OfficeCode, string UserCode)
        {
            return abbsSavingWithdrawlDao.GetAbbsSavingWithdrawal(OfficeCode, UserCode);
        }

    }
}