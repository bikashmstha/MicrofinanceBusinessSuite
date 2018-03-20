using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeAdditionalLoanDetailDao
    {
        object Get();

        object Save(MeAdditionalLoanDetail meAdditionalLoanDetail);

        object Search(MeAdditionalLoanDetail meAdditionalLoanDetail);

        object GetMeAdditionalLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo);

    }
}
