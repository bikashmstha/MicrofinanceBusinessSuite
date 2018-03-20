using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfLoanDetailDao
    {
        object Get();

        object Save(MfLoanDetail mfLoanDetail);

        object Search(MfLoanDetail mfLoanDetail);

        object GetMfLoanDetail(string offCode, string clientName, string loanNo, string loanDateFrom, string loanDateTo);

    }
}
