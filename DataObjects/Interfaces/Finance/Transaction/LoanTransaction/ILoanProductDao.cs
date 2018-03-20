using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanProductDao
    {
        object Get();

        object SaveLoanProduct(LoanProduct loanProduct);

        object Search(LoanProduct loanProduct);

        object GetLoanProduct(string productName);

    }
}
