using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfLoanRepaymentController : ControllerBase
    {
        private static IMfLoanRepaymentDao mfLoanRepaymentDao = DataAccess.MfLoanRepaymentDao;

        public object Get()
        {
            return mfLoanRepaymentDao.Get();
        }

        public object Save(MfRepayLoan mfLoanRepayment)
        {
            return mfLoanRepaymentDao.Save(mfLoanRepayment);
        }
        public object Search(MfRepayLoan mfLoanRepayment)
        {
            return mfLoanRepaymentDao.Search(mfLoanRepayment);
        }

        public object GetMfRepayLoan(string offCode, string centerCode, string productCode, string clientName)
        {
            return mfLoanRepaymentDao.GetMfRepayLoan(offCode,centerCode,productCode,clientName);
        }

        public object SaveLoanRepayment(MfLoanRepayment mfLoanRepayment)
        {
            return mfLoanRepaymentDao.SaveLoanRepayment(mfLoanRepayment);
        }
    }
}