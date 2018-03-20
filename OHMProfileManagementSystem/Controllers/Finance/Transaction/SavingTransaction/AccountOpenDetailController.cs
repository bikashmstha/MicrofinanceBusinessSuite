using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class AccountOpenDetailController : ControllerBase
    {
        private static IAccountOpenDetailDao accountOpenDetailDao = DataAccess.AccountOpenDetailDao;

        public object Get()
        {
            return accountOpenDetailDao.Get();
        }

        public object Save(AccountOpenDetail accountOpenDetail)
        {
            return accountOpenDetailDao.Save(accountOpenDetail);
        }
        public object Search(AccountOpenDetail accountOpenDetail)
        {
            return accountOpenDetailDao.Search(accountOpenDetail);
        }
        public object GetAccountOpenDetail(string withdrawlNo, string offCode, string savingAccountNo, string clientName, string fromDate, string toDate)
        {
            return accountOpenDetailDao.GetAccountOpenDetail(withdrawlNo,offCode,savingAccountNo,clientName,fromDate,toDate);
        }
    }
}