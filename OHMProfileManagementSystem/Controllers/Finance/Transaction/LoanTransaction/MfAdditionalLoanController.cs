using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MfAdditionalLoanController : ControllerBase
    {
        private static IMfAdditionalLoanDao mfAdditionalLoanDao = DataAccess.MfAdditionalLoanDao;

        public object Get()
        {
            return mfAdditionalLoanDao.Get();
        }

        public object Save(MfAdditionalLoan mfAdditionalLoan)
        {
            return mfAdditionalLoanDao.Save(mfAdditionalLoan);
        }
        public object Search(MfAdditionalLoan mfAdditionalLoan)
        {
            return mfAdditionalLoanDao.Search(mfAdditionalLoan);
        }
        public object GetMfAdditionalLoan(string offCode, string centerCode, string clientName)
        {
            return mfAdditionalLoanDao.GetMfAdditionalLoan(offCode,centerCode,clientName);
        }
    }
}