using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class AccountForWithdrawlController : ControllerBase
    {
        private static IAccountForWithdrawlDao accountForWithdrawlDao = DataAccess.AccountForWithdrawlDao;

        public object Get()
        {
            return accountForWithdrawlDao.Get();
        }

        public object Save(AccountForWithdrawl accountForWithdrawl)
        {
            return accountForWithdrawlDao.Save(accountForWithdrawl);
        }
        public object Search(AccountForWithdrawl accountForWithdrawl)
        {
            return accountForWithdrawlDao.Search(accountForWithdrawl);
        }

        public object GetAccountForWithdrawl( string offCode, string productCode, string savingAccountNo, string centerCode)
        {
            return accountForWithdrawlDao.GetAccountForWithdrawl(offCode, productCode, savingAccountNo, centerCode);
        }
    }
}