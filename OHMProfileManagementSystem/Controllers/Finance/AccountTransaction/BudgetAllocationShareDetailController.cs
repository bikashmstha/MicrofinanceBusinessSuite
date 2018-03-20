using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class BudgetAllocationShareDetailController : ControllerBase
    {
        private static IBudgetAllocationShareDetailDao budgetAllocationShareDetailDao = DataAccess.BudgetAllocationShareDetailDao;



        public object SaveBudgetAllocationShareDetail(BudgetAllocationShareDetail budgetAllocationShareDetail)
        {
            return budgetAllocationShareDetailDao.SaveBudgetAllocationShareDetail(budgetAllocationShareDetail);
        }
        public object SearchBudgetAllocationShareDetail(BudgetAllocationShareDetail budgetAllocationShareDetail)
        {
            return budgetAllocationShareDetailDao.SearchBudgetAllocationShareDetail(budgetAllocationShareDetail);
        }

        public object GetBudAllocShareDetail(string OfficeCode, string FiscalYear, string AccountCode)
        {
            return budgetAllocationShareDetailDao.GetBudAllocShareDetail(OfficeCode, FiscalYear, AccountCode);
        }

    }
}