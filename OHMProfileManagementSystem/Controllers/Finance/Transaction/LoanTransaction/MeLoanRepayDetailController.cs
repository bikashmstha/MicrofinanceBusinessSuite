using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeLoanRepayDetailController : ControllerBase
    {
        private static IMeLoanRepayDetailDao meLoanRepayDetailDao = DataAccess.MeLoanRepayDetailDao;

        public object Get()
        {
            return meLoanRepayDetailDao.Get();
        }

        public object Save(MeLoanRepayDetail meLoanRepayDetail)
        {
            return meLoanRepayDetailDao.Save(meLoanRepayDetail);
        }
        public object Search(MeLoanRepayDetail meLoanRepayDetail)
        {
            return meLoanRepayDetailDao.Search(meLoanRepayDetail);
        }
        public object GetMeLoanRepayDetail(string offCode, string repaymentNo, string clientName, string loanDno, string dateFrom, string dateTo )
        {
            return meLoanRepayDetailDao.GetMeLoanRepayDetail(offCode, repaymentNo,clientName,loanDno,dateFrom,dateTo);
        }
    }
}