using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfLoanRepaymentDao
    {
        object Get();

        object Save(MfRepayLoan mfLoanRepayment);

        object Search(MfRepayLoan mfLoanRepayment);

        object SaveLoanRepayment(MfLoanRepayment mfLoanRepayment);

        object GetMfRepayLoan(string offCode, string centerCode, string productCode, string clientName);

    }
}
