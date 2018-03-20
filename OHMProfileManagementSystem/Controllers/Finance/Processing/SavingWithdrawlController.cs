using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class SavingWithdrawlController : ControllerBase
    {
        private static ISavingWithdrawlDao savingWithdrawlDao = DataAccess.SavingWithdrawlDao;



        public object SaveSavingWithdrawl(SavingWithdrawl savingWithdrawl)
        {
            return savingWithdrawlDao.SaveSavingWithdrawl(savingWithdrawl);
        }
        public object SearchSavingWithdrawl(SavingWithdrawl savingWithdrawl)
        {
            return savingWithdrawlDao.SearchSavingWithdrawl(savingWithdrawl);
        }

        public object GetSavingWithdrawal(string OfficeCode, string UserCode)
        {
            return savingWithdrawlDao.GetSavingWithdrawal(OfficeCode, UserCode);
        }

    }
}