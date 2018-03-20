using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IBudgetAllocationDetailDetailDao
    {


        object SaveBudgetAllocationDetailDetail(BudgetAllocationDetailDetail budgetAllocationDetailDetail);

        object SearchBudgetAllocationDetailDetail(BudgetAllocationDetailDetail budgetAllocationDetailDetail);



        object GetBudAllocDtlDetail(string OfficeCode, string FiscalYear);

    }
}
