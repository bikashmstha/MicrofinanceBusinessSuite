using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeLoanRepayDetailDao
    {
        object Get();

        object Save(MeLoanRepayDetail meLoanRepayDetail);

        object Search(MeLoanRepayDetail meLoanRepayDetail);

        object GetMeLoanRepayDetail(string offCode, string repaymentNo, string clientName, string loanDno, string dateFrom, string dateTo);

    }
}
