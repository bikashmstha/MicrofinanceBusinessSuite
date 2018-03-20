using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LoanRepaymentController : ControllerBase
    {
        private static ILoanRepaymentDao loanRepaymentDao = DataAccess.LoanRepaymentDao;



        public object SaveLoanRepayment(LoanRepayment loanRepayment)
        {
            return loanRepaymentDao.SaveLoanRepayment(loanRepayment);
        }
        public object SearchLoanRepayment(LoanRepayment loanRepayment)
        {
            return loanRepaymentDao.SearchLoanRepayment(loanRepayment);
        }

        public object GetLoanRepayment(string OfficeCode, string UserCode)
        {
            return loanRepaymentDao.GetLoanRepayment(OfficeCode, UserCode);
        }

    }
}