using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class AccountForDepositController : ControllerBase
    {
        private static IAccountForDepositDao accountForDepositDao = DataAccess.AccountForDepositDao;

        public object Get()
        {
            return accountForDepositDao.Get();
        }

        public object Save(AccountForDeposit accountForDeposit)
        {
            return accountForDepositDao.Save(accountForDeposit);
        }
        public object Search(AccountForDeposit accountForDeposit)
        {
            return accountForDepositDao.Search(accountForDeposit);
        }
        public object GetAccountForDeposit(string offCode,string productCode, string savingAccountNo, string centerCode)
        {
            return accountForDepositDao.GetAccountForDeposit(offCode,productCode,savingAccountNo,centerCode);
        }
    }
}