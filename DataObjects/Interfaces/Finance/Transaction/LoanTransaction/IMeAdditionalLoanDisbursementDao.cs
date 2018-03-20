using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMeAdditionalLoanDisbursementDao
    {
        object Get();

        object Save(MeAdditionalLoanDisbursement meAdditionalLoanDisbursement);

        object Search(MeAdditionalLoanDisbursement meAdditionalLoanDisbursement);

    }
}
