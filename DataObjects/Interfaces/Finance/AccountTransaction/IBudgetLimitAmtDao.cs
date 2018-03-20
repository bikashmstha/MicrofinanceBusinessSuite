using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IBudgetLimitAmtDao
    {


        object SaveBudgetLimitAmt(BudgetLimitAmt budgetLimitAmt);

        object SearchBudgetLimitAmt(BudgetLimitAmt budgetLimitAmt);



        object GetBudgetLimitAmount(string FiscalYear, string TransactionDate, string TranOfficeCode, string AccountCode);

    }
}
