using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class AccountForClosingController : ControllerBase
    {
        private static IAccountForClosingDao accountForClosingDao = DataAccess.AccountForClosingDao;

        public object Get()
        {
            return accountForClosingDao.Get();
        }

        public object Save(AccountForClosing accountForClosing)
        {
            return accountForClosingDao.Save(accountForClosing);
        }
        public object Search(AccountForClosing accountForClosing)
        {
            return accountForClosingDao.Search(accountForClosing);
        }

        public object GetAccountForClosing(string offCode, string productCode, string centerCode, string savingAccountNo)
        {
            return accountForClosingDao.GetAccountForClosing(offCode, productCode,centerCode,savingAccountNo);
        }
    }
}