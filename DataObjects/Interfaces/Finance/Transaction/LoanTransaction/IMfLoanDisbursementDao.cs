using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfLoanDisbursementDao
    {
        object Get();

        object Save(MfLoanDisbursement mfLoanDisbursement);

        object Search(MfLoanDisbursement mfLoanDisbursement);

    }
}
