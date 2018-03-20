using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeLoanDetailController : ControllerBase
    {
        private static IMeLoanDetailDao meLoanDetailDao = DataAccess.MeLoanDetailDao;

        public object Get()
        {
            return meLoanDetailDao.Get();
        }

        public object Save(MeLoanDetail meLoanDetail)
        {
            return meLoanDetailDao.Save(meLoanDetail);
        }
        public object Search(MeLoanDetail meLoanDetail)
        {
            return meLoanDetailDao.Search(meLoanDetail);
        }

        public object GetMeLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo)
        {
            return meLoanDetailDao.GetMeLoanDetail(offCode,clientName,loanNo,dateFrom,dateTo);
        }
    }
}