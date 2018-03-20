using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LoanRepaymentPostingController : ControllerBase
    {
        private static ILoanRepaymentPostingDao loanRepaymentPostingDao = DataAccess.LoanRepaymentPostingDao;



        public object SaveLoanRepaymentPosting(List<LoanRepaymentPosting> loanRepaymentPosting)
        {
            return loanRepaymentPostingDao.SaveLoanRepaymentPosting(loanRepaymentPosting);
        }
        public object SearchLoanRepaymentPosting(LoanRepaymentPosting loanRepaymentPosting)
        {
            return loanRepaymentPostingDao.SearchLoanRepaymentPosting(loanRepaymentPosting);
        }
    }
}