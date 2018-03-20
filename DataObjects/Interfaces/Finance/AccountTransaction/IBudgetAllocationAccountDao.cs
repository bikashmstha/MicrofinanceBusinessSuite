using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IBudgetAllocationAccountDao
    {


        object SaveBudgetAllocationAccount(BudgetAllocationAccount budgetAllocationAccount);

        object SearchBudgetAllocationAccount(BudgetAllocationAccount budgetAllocationAccount);



        object GetBudAllocAcc(string AccountDesc);

    }
}
