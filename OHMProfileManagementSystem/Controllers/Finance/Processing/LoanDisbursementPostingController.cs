using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LoanDisbursementPostingController : ControllerBase
    {
        private static ILoanDisbursementPostingDao loanDisbursementPostingDao = DataAccess.LoanDisbursementPostingDao;



        public object SaveLoanDisbursementPosting(List<LoanDisbursementPosting> loanDisbursementPostings)
        {
            return loanDisbursementPostingDao.SaveLoanDisbursementPosting(loanDisbursementPostings);
        }
        public object SearchLoanDisbursementPosting(LoanDisbursementPosting loanDisbursementPosting)
        {
            return loanDisbursementPostingDao.SearchLoanDisbursementPosting(loanDisbursementPosting);
        }
    }
}