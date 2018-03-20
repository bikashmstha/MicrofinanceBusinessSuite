using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IBudgetAllocationShareDetailDao
    {


        object SaveBudgetAllocationShareDetail(BudgetAllocationShareDetail budgetAllocationShareDetail);

        object SearchBudgetAllocationShareDetail(BudgetAllocationShareDetail budgetAllocationShareDetail);



        object GetBudAllocShareDetail(string OfficeCode, string FiscalYear, string AccountCode);

    }
}
