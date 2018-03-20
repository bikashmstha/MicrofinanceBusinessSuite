using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfAdjustSavingController : ControllerBase
    {
        private static IMfAdjustSavingDao mfAdjustSavingDao = DataAccess.MfAdjustSavingDao;

        public object Get()
        {
            return mfAdjustSavingDao.Get();
        }
        public object Save(MfAdjustSaving mfAdjustSaving)
        {
            return mfAdjustSavingDao.Save(mfAdjustSaving);
        }
        public object GetMfAdjustSaving(string offCode, string clientNo, string productName)
        {
            return mfAdjustSavingDao.GetMfAdjustSaving(offCode,clientNo,productName);
        }
    }
}