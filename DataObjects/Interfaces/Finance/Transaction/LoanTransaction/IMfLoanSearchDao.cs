using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfLoanSearchDao
    {
        object Get();

        object Save(MfLoanSearch mfLoanSearch);

        object Search(MfLoanSearch mfLoanSearch);

        object GetMfLoanSearch(string offCode, string loanDno);

    }
}
