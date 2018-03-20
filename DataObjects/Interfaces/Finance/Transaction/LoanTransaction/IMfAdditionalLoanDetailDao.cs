using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfAdditionalLoanDetailDao
    {
        object Get();

        object Save(MfAdditionalLoanDetail mfAdditionalLoanDetail);

        object Search(MfAdditionalLoanDetail mfAdditionalLoanDetail);

        object GetMfAdditionalLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo);

    }
}
