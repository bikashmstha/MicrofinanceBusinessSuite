using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanUtilizationEntryDao
    {
        object Get();

        object Save(LoanUtilizationEntry loanUtilizationEntry);

        object Search(LoanUtilizationEntry loanUtilizationEntry);

    }
}
