using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfRepayAdjustSavingController : ControllerBase
    {
        private static IMfRepayAdjustSavingDao mfRepayAdjustSavingDao = DataAccess.MfRepayAdjustSavingDao;

        public object Get()
        {
            return mfRepayAdjustSavingDao.Get();
        }

        public object Save(MfRepayAdjustSaving mfRepayAdjustSaving)
        {
            return mfRepayAdjustSavingDao.Save(mfRepayAdjustSaving);
        }
        public object Search(MfRepayAdjustSaving mfRepayAdjustSaving)
        {
            return mfRepayAdjustSavingDao.Search(mfRepayAdjustSaving);
        }
        public object GetMfRepayAdjustSaving(string offCode, string clientNo, string productName)
        {
            return mfRepayAdjustSavingDao.GetMfRepayAdjustSaving(offCode, clientNo, productName);
        }
    }
}