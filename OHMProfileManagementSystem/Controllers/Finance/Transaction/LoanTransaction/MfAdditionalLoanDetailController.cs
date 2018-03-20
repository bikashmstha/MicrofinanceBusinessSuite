using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfAdditionalLoanDetailController : ControllerBase
    {
        private static IMfAdditionalLoanDetailDao mfAdditionalLoanDetailDao = DataAccess.MfAdditionalLoanDetailDao;

        public object Get()
        {
            return mfAdditionalLoanDetailDao.Get();
        }

        public object Save(MfAdditionalLoanDetail mfAdditionalLoanDetail)
        {
            return mfAdditionalLoanDetailDao.Save(mfAdditionalLoanDetail);
        }
        public object Search(MfAdditionalLoanDetail mfAdditionalLoanDetail)
        {
            return mfAdditionalLoanDetailDao.Search(mfAdditionalLoanDetail);
        }

        public object GetMfAdditionalLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo)
        {
            return mfAdditionalLoanDetailDao.GetMfAdditionalLoanDetail(offCode, clientName,loanNo,dateFrom,dateTo);
        }
    }
}