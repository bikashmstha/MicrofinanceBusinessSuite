using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfSavingDepositEditController : ControllerBase
    {
        private static IMfSavingDepositEditDao mfSavingDepositEditDao = DataAccess.MfSavingDepositEditDao;

        public object Get()
        {
            return mfSavingDepositEditDao.Get();
        }

        public object Save(MfSavingDepositEdit mfSavingDepositEdit)
        {
            return mfSavingDepositEditDao.Save(mfSavingDepositEdit);
        }
        public object Search(MfSavingDepositEdit mfSavingDepositEdit)
        {
            return mfSavingDepositEditDao.Search(mfSavingDepositEdit);
        }
    }
}