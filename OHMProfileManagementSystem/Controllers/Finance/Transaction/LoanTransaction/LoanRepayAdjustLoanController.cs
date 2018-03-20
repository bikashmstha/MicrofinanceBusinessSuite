using DataObjects;
using DataObjects.Interfaces.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanRepayAdjustLoanController
    {
        private static ILoanRepayAdjustLoanDao loanDao = DataAccess.LoanRepayAdjustLoanDao;

        public object GetLoanRepayAdjustLoan(string OfficeCode, string ClientName, string FromDate, string ToDate)
        {
            return loanDao.GetLoanRepayAdjustLoan(OfficeCode,ClientName,FromDate,ToDate);
        }
        //public object GetLoanProduct(string productName)
        //{
        //    return loanDao.GetLoanProduct(productName);
        //}
    }
}