using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanAdjustLoanDao
    {
        object Get();

        object Save(LoanAdjustLoan loanAdjustLoan);

        object Search(LoanAdjustLoan loanAdjustLoan);

        object GetLoanAdjustLoan(string OfficeCode, string LoanDno);

    }
}
