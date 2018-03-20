using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfSavingDepositEditDao
    {
        object Get();

        object Save(MfSavingDepositEdit mfSavingDeposit);

        object Search(MfSavingDepositEdit mfSavingDeposit);

    }
}
