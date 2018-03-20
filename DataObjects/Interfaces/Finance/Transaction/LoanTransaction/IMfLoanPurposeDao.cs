using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfLoanPurposeDao
    {
        object Get();

        object Save(MfLoanPurpose mfLoanPurpose);

        object Search(MfLoanPurpose mfLoanPurpose);

        object GetLoanProduct(string productCode, string purposeName);

    }
}
