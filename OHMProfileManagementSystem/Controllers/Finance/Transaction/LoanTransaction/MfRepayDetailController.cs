using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfRepayDetailController : ControllerBase
    {
        private static IMfRepayDetailDao mfRepayDetailDao = DataAccess.MfRepayDetailDao;

        public object Get()
        {
            return mfRepayDetailDao.Get();
        }

        public object Save(MfRepayDetail mfRepayDetail)
        {
            return mfRepayDetailDao.Save(mfRepayDetail);
        }
        public object Search(MfRepayDetail mfRepayDetail)
        {
            return mfRepayDetailDao.Search(mfRepayDetail);
        }
        public object GetMfRepayDetail(string offCode, string clientName, string loanDno, string repaymentNo, string dateForm, string dateTo)
        {
            return mfRepayDetailDao.GetMfRepayDetail(offCode, clientName,loanDno,repaymentNo,dateForm,dateTo);
        }
    }
}