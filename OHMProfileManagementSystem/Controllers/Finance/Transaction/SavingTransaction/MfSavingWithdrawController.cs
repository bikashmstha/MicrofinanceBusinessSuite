using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class SavingWithdrawController : ControllerBase
    {
        private static IMfSavingWithdrawDao savingWithdrawDao = DataAccess.MfSavingWithdrawDao;

        public object Get()
        {
            return savingWithdrawDao.Get();
        }

        public object Save(MfSavingWithdraw savingWithdraw)
        {
            return savingWithdrawDao.Save(savingWithdraw);
        }
        public object Search(MfSavingWithdraw savingWithdraw)
        {
            return savingWithdrawDao.Search(savingWithdraw);
        }
    }
}