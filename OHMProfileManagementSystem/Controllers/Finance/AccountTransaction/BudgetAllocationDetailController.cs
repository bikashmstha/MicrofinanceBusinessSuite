using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class BudgetAllocationDetailController : ControllerBase
    {
        private static IBudgetAllocationDetailDao budgetAllocationDetailDao = DataAccess.BudgetAllocationDetailDao;



        
        public object SearchBudgetAllocationDetail(BudgetAllocationDetail budgetAllocationDetail)
        {
            return budgetAllocationDetailDao.SearchBudgetAllocationDetail(budgetAllocationDetail);
        }
    }
}