using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class MfDepositDetailController : ControllerBase
    {
        private static IMfDepositDetailDao mFDepositDetailDao = DataAccess.MfDepositDetailDao;

        public object Get()
        {
            return mFDepositDetailDao.Get();
        }

        public object Save(MfDepositDetail mFDepositDetail)
        {
            return mFDepositDetailDao.Save(mFDepositDetail);
        }
        public object Search(MfDepositDetail mFDepositDetail)
        {
            return mFDepositDetailDao.Search(mFDepositDetail);
        }
        public object GetMfDepositDetail(string offCode, long? depositNo, string savingAccountNo, string clientName, string fromDate, string toDate)
        {
            return mFDepositDetailDao.GetMfDepositDetail(offCode, depositNo,savingAccountNo,clientName,fromDate,toDate);
        }

    }
}