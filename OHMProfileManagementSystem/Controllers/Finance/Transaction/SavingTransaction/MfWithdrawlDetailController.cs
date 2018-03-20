using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class MfWithdrawlDetailController : ControllerBase
    {
        private static IMfWithdrawlDetailDao mfWithDrawlDetailDao = DataAccess.MfWithdrawlDetailDao;

        public object Get()
        {
            return mfWithDrawlDetailDao.Get();
        }

        public object Save(MfWithdrawlDetail mfWithDrawlDetail)
        {
            return mfWithDrawlDetailDao.Save(mfWithDrawlDetail);
        }
        public object Search(MfWithdrawlDetail mfWithDrawlDetail)
        {
            return mfWithDrawlDetailDao.Search(mfWithDrawlDetail);
        }

        public object GetMfWithdrawDetail( string offCode, long? withdrawlNo, string savingAccountNo, string clientName, string fromDate, string toDate)
        {
            return mfWithDrawlDetailDao.GetMfWithdrawDetail(offCode, withdrawlNo, savingAccountNo, clientName, fromDate, toDate);
        }
    }
}