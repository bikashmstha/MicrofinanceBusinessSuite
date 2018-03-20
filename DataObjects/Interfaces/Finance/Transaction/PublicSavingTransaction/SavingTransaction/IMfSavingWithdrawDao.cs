using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IMfSavingWithdrawDao
    {
        object Get();

        object Save(MfSavingWithdraw savingWithdraw);

        object Search(MfSavingWithdraw savingWithdraw);

    }
}
