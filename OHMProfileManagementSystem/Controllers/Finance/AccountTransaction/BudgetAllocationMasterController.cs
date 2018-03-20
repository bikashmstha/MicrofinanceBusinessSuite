using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class BudgetAllocationMasterController : ControllerBase
    {
        private static IBudgetAllocationMasterDao budgetAllocationMasterDao = DataAccess.BudgetAllocationMasterDao;



        public object SaveBudgetAllocationMaster(BudgetAllocationMaster budgetAllocationMaster)
        {
            return budgetAllocationMasterDao.SaveBudgetAllocationMaster(budgetAllocationMaster);
        }
        public object SearchBudgetAllocationMaster(BudgetAllocationMaster budgetAllocationMaster)
        {
            return budgetAllocationMasterDao.SearchBudgetAllocationMaster(budgetAllocationMaster);
        }
    }
}