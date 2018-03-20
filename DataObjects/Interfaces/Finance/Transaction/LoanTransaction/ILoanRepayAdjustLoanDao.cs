using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanRepayAdjustLoanDao
    {
        object Get();

        object Save(LoanRepayAdjustLoan loanRepayAdjustLoan);

        object Search(LoanRepayAdjustLoan loanRepayAdjustLoan);



        object GetLoanRepayAdjustLoan(string OfficeCode, string ClientName, string FromDate, string ToDate);

    }
}
