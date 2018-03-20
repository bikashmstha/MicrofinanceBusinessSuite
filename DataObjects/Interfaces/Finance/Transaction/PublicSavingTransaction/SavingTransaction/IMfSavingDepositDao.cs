using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfSavingDepositDao
    {
        object Get();

        object Save(MfSavingDeposit mfSavingDeposit);

        object Search(MfSavingDeposit mfSavingDeposit);

    }
}
