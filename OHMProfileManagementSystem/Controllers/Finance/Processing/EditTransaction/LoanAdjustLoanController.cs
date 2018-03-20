using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class LoanAdjustLoanController : ControllerBase
    {
        private static ILoanAdjustLoanDao loanAdjustLoanDao = DataAccess.LoanAdjustLoanDao;

        public object Get()
        {
            return loanAdjustLoanDao.Get();
        }

        public object Save(LoanAdjustLoan loanAdjustLoan)
        {
            return loanAdjustLoanDao.Save(loanAdjustLoan);
        }
        public object Search(LoanAdjustLoan loanAdjustLoan)
        {
            return loanAdjustLoanDao.Search(loanAdjustLoan);
        }

        public object GetLoanAdjustLoan(string OfficeCode, string LoanDno)
        {
            return loanAdjustLoanDao.GetLoanAdjustLoan(OfficeCode, LoanDno);
        }

    }
}