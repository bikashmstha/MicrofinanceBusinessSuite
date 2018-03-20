using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class MfSavingDepositController : ControllerBase
    {
        private static IMfSavingDepositDao mfSavingDepositDao = DataAccess.MfSavingDepositDao;

        public object Get()
        {
            return mfSavingDepositDao.Get();
        }

        public object Save(MfSavingDeposit mfSavingDeposit)
        {
            return mfSavingDepositDao.Save(mfSavingDeposit);
        }
        public object Search(MfSavingDeposit mfSavingDeposit)
        {
            return mfSavingDepositDao.Search(mfSavingDeposit);
        }
    }
}