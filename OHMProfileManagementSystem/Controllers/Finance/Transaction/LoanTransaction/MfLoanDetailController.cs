using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfLoanDetailController : ControllerBase
    {
        private static IMfLoanDetailDao mfLoanDetailDao = DataAccess.MfLoanDetailDao;

        public object Get()
        {
            return mfLoanDetailDao.Get();
        }

        public object Save(MfLoanDetail mfLoanDetail)
        {
            return mfLoanDetailDao.Save(mfLoanDetail);
        }
        public object Search(MfLoanDetail mfLoanDetail)
        {
            return mfLoanDetailDao.Search(mfLoanDetail);
        }
        public object GetMfLoanDetail(string offCode, string clientName, string loanNo, string loanDateFrom, string loanDateTo)
        {
            return mfLoanDetailDao.GetMfLoanDetail(offCode, clientName,loanNo,loanDateFrom,loanDateTo);
        }
    }
}