using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfLoanSearchController : ControllerBase
    {
        private static IMfLoanSearchDao mfLoanSearchDao = DataAccess.MfLoanSearchDao;

        public object Get()
        {
            return mfLoanSearchDao.Get();
        }

        public object Save(MfLoanSearch mfLoanSearch)
        {
            return mfLoanSearchDao.Save(mfLoanSearch);
        }
        public object Search(MfLoanSearch mfLoanSearch)
        {
            return mfLoanSearchDao.Search(mfLoanSearch);
        }
        public object GetMfLoanSearch(string offCode, string loanDno)
        {
            return mfLoanSearchDao.GetMfLoanSearch(offCode,loanDno);
        }
    }
}