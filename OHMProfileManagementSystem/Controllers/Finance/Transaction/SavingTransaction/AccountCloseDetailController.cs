using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class AccountCloseDetailController : ControllerBase
    {
        private static IAccountCloseDetailDao accountCloseDetailDao = DataAccess.AccountCloseDetailDao;

        public object Get()
        {
            return accountCloseDetailDao.Get();
        }

        public object Save(AccountCloseDetail accountCloseDetail)
        {
            return accountCloseDetailDao.Save(accountCloseDetail);
        }
        public object Search(AccountCloseDetail accountCloseDetail)
        {
            return accountCloseDetailDao.Search(accountCloseDetail);
        }
        public object GetAccountCloseDetail(string withdrawlNo, string offCode, string savingAccountNo, string clientName, string fromDate, string toDate)
        {
            return accountCloseDetailDao.GetAccountCloseDetail(withdrawlNo,offCode, savingAccountNo,clientName,fromDate,toDate);
        }
    }
}