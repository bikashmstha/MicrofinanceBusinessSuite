using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class BudgetAllocationDetailDetailController : ControllerBase
    {
        private static IBudgetAllocationDetailDetailDao budgetAllocationDetailDetailDao = DataAccess.BudgetAllocationDetailDetailDao;



        public object SaveBudgetAllocationDetailDetail(BudgetAllocationDetailDetail budgetAllocationDetailDetail)
        {
            return budgetAllocationDetailDetailDao.SaveBudgetAllocationDetailDetail(budgetAllocationDetailDetail);
        }
        public object SearchBudgetAllocationDetailDetail(BudgetAllocationDetailDetail budgetAllocationDetailDetail)
        {
            return budgetAllocationDetailDetailDao.SearchBudgetAllocationDetailDetail(budgetAllocationDetailDetail);
        }

        public object GetBudAllocDtlDetail(string OfficeCode, string FiscalYear)
        {
            return budgetAllocationDetailDetailDao.GetBudAllocDtlDetail(OfficeCode, FiscalYear);
        }

    }
}