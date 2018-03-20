using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfRepaySearchLoanDao
    {
        object Get();

        object Save(MfRepaySearchLoan mfRepaySearchLoan);

        object Search(MfRepaySearchLoan mfRepaySearchLoan);

        object GetMfRepaySearchLoan(string offCode, string loanDno);

    }
}
