using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeLoanDetailDao
    {
        object Get();

        object Save(MeLoanDetail meLoanDetail);

        object Search(MeLoanDetail meLoanDetail);

        object GetMeLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo);

    }
}
