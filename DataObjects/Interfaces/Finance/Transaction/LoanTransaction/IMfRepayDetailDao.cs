using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfRepayDetailDao
    {
        object Get();

        object Save(MfRepayDetail mfRepayDetail);

        object Search(MfRepayDetail mfRepayDetail);

        object GetMfRepayDetail(string offCode, string clientName, string loanDno, string repaymentNo, string dateForm, string dateTo);

    }
}
