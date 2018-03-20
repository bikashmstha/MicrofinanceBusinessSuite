using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IAccountForDepositDao
    {
        object Get();

        object Save(AccountForDeposit accountForDeposit);

        object Search(AccountForDeposit accountForDeposit);

        object GetAccountForDeposit(string offCode, string productCode, string savingAccountNo, string centerCode);

    }
}
