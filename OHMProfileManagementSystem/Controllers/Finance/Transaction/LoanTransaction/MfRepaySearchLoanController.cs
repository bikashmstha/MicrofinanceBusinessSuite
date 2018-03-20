using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfRepaySearchLoanController : ControllerBase
    {
        private static IMfRepaySearchLoanDao mfRepaySearchLoanDao = DataAccess.MfRepaySearchLoanDao;

        public object Get()
        {
            return mfRepaySearchLoanDao.Get();
        }

        public object Save(MfRepaySearchLoan mfRepaySearchLoan)
        {
            return mfRepaySearchLoanDao.Save(mfRepaySearchLoan);
        }
        public object Search(MfRepaySearchLoan mfRepaySearchLoan)
        {
            return mfRepaySearchLoanDao.Search(mfRepaySearchLoan);
        }
        public object GetMfRepaySearchLoan(string offCode, string loanDno)
        {
            return mfRepaySearchLoanDao.GetMfRepaySearchLoan(offCode, loanDno);
        }
    }
}