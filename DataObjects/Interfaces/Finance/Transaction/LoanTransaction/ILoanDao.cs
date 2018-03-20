using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanDao
    {
        object Get();

        object Save(FLoan loan);

        object Search(FLoan loan);

    }
}
