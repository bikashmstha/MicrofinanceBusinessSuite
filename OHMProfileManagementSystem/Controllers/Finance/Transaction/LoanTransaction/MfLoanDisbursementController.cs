using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfLoanDisbursementController : ControllerBase
    {
        private static IMfLoanDisbursementDao mfLoanDisbursementDao = DataAccess.MfLoanDisbursementDao;

        public object Get()
        {
            return mfLoanDisbursementDao.Get();
        }

        public object Save(MfLoanDisbursement mfLoanDisbursement)
        {
            return mfLoanDisbursementDao.Save(mfLoanDisbursement);
        }
        public object Search(MfLoanDisbursement mfLoanDisbursement)
        {
            return mfLoanDisbursementDao.Search(mfLoanDisbursement);
        }
    }
}