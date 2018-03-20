using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanController : ControllerBase
    {
        private static ILoanDao loanDao = DataAccess.LoanDao;

        public object Get()
        {
            return loanDao.Get();
        }

        public object Save(FLoan loan)
        {
            return loanDao.Save(loan);
        }
        public object Search(FLoan loan)
        {
            return loanDao.Search(loan);
        }
    }
}