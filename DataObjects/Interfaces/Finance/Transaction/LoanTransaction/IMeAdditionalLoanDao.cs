using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeAdditionalLoanDao
    {
        object Get();

        object Save(MeAdditionalLoan meAdditionalLoan);

        object Search(MeAdditionalLoan meAdditionalLoan);

        object GetMeAdditionalLoan(string offCode, string productCode, string clientName);

    }
}
