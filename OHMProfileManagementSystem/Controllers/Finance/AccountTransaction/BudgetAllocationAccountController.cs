using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class BudgetAllocationAccountController : ControllerBase
    {
        private static IBudgetAllocationAccountDao budgetAllocationAccountDao = DataAccess.BudgetAllocationAccountDao;



        public object SaveBudgetAllocationAccount(BudgetAllocationAccount budgetAllocationAccount)
        {
            return budgetAllocationAccountDao.SaveBudgetAllocationAccount(budgetAllocationAccount);
        }
        public object SearchBudgetAllocationAccount(BudgetAllocationAccount budgetAllocationAccount)
        {
            return budgetAllocationAccountDao.SearchBudgetAllocationAccount(budgetAllocationAccount);
        }

        public object GetBudAllocAcc(string AccountDesc)
        {
            return budgetAllocationAccountDao.GetBudAllocAcc(AccountDesc);
        }

    }
}