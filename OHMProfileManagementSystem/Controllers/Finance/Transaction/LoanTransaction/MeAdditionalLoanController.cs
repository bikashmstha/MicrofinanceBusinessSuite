using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class MeAdditionalLoanController : ControllerBase
    {
        private static IMeAdditionalLoanDao meAdditionalLoanDao = DataAccess.MeAdditionalLoanDao;

        public object Get()
        {
            return meAdditionalLoanDao.Get();
        }

        public object Save(MeAdditionalLoan meAdditionalLoan)
        {
            return meAdditionalLoanDao.Save(meAdditionalLoan);
        }
        public object Search(MeAdditionalLoan meAdditionalLoan)
        {
            return meAdditionalLoanDao.Search(meAdditionalLoan);
        }
        public object GetMeAdditionalLoan(string offCode, string productCode, string clientName)
        {
            return meAdditionalLoanDao.GetMeAdditionalLoan(offCode, productCode,clientName);
        }
    }
}