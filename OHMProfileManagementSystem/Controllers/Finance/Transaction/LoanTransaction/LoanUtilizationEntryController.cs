using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LoanUtilizationEntryController : ControllerBase
    {
        private static ILoanUtilizationEntryDao loanUtilizationEntryDao = DataAccess.LoanUtilizationEntryDao;

        public object Get()
        {
            return loanUtilizationEntryDao.Get();
        }

        public object Save(LoanUtilizationEntry loanUtilizationEntry)
        {
            return loanUtilizationEntryDao.Save(loanUtilizationEntry);
        }
        public object Search(LoanUtilizationEntry loanUtilizationEntry)
        {
            return loanUtilizationEntryDao.Search(loanUtilizationEntry);
        }
    }
}