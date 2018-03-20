using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingAccountClosureDao
    {
        object Get();

        object Save(SavingAccountClosure savingAccountClosure);

        object Search(SavingAccountClosure savingAccountClosure);

    }
}
