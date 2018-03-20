using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfAdditionalLoanDisbursementDao
    {
        object Get();

        object Save(MfAdditionalLoanDisbursement mfAdditionalLoanDisbursement);

        object Search(MfAdditionalLoanDisbursement mfAdditionalLoanDisbursement);

    }
}
