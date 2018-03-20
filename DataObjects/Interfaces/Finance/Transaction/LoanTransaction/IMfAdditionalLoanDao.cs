using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfAdditionalLoanDao
    {
        object Get();

        object Save(MfAdditionalLoan mfAdditionalLoan);

        object Search(MfAdditionalLoan mfAdditionalLoan);

        object GetMfAdditionalLoan(string offCode, string centerCode, string clientName);

    }
}
