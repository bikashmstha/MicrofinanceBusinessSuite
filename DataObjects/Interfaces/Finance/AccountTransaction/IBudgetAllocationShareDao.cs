using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;
using Oracle.DataAccess.Client;

namespace DataObjects.Interfaces.Finance
{
    public interface IBudgetAllocationShareDao
    {


        object SaveBudgetAllocationShare(BudgetAllocationShare budgetAllocationShare);

        object SearchBudgetAllocationShare(BudgetAllocationShare budgetAllocationShare);


    }
}
