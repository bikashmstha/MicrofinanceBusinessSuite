using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class BudgetAllocationShareController : ControllerBase
{
          private static IBudgetAllocationShareDao budgetAllocationShareDao = DataAccess.BudgetAllocationShareDao;



          public object SaveBudgetAllocationShare(BudgetAllocationShare budgetAllocationShare)          {
                    return budgetAllocationShareDao.SaveBudgetAllocationShare(budgetAllocationShare);
          }
          public object SearchBudgetAllocationShare(BudgetAllocationShare budgetAllocationShare)
          {
                    return budgetAllocationShareDao.SearchBudgetAllocationShare(budgetAllocationShare);
          }



}
}