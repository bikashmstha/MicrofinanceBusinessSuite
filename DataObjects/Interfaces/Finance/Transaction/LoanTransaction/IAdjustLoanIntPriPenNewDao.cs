using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IAdjustLoanIntPriPenNewDao
    {
        object Get();

        object Save(AdjustLoanIntPriPenNew adjustLoanIntPriPenNew);

        object Search(AdjustLoanIntPriPenNew adjustLoanIntPriPenNew);

    }
}
