using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILnUtilizationLoanDao
    {
        object Get();

        object Save(LnUtilizationLoan lnUtilizationLoan);

        object Search(LnUtilizationLoan lnUtilizationLoan);



        object GetLnUtilizationLoan(string CenterCode, string ClientName);

    }
}
