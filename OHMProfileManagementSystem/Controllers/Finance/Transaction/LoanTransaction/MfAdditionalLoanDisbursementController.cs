using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfAdditionalLoanDisbursementController : ControllerBase
    {
        private static IMfAdditionalLoanDisbursementDao mfAdditionalLoanDisbursementDao = DataAccess.MfAdditionalLoanDisbursementDao;

        public object Get()
        {
            return mfAdditionalLoanDisbursementDao.Get();
        }

        public object Save(MfAdditionalLoanDisbursement mfAdditionalLoanDisbursement)
        {
            return mfAdditionalLoanDisbursementDao.Save(mfAdditionalLoanDisbursement);
        }
        public object Search(MfAdditionalLoanDisbursement mfAdditionalLoanDisbursement)
        {
            return mfAdditionalLoanDisbursementDao.Search(mfAdditionalLoanDisbursement);
        }
    }
}