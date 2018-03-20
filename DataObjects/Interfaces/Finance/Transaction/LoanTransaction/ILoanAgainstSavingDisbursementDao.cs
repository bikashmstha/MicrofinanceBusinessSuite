using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILoanAgainstSavingDisbursementDao
    {
        object Get();

        object Save(LoanAgainstSavingDisbursement loanAgainstSavingDisbursement);

        object Search(LoanAgainstSavingDisbursement loanAgainstSavingDisbursement);

    }
}
