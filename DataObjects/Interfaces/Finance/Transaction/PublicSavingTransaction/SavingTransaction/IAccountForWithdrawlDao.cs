using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IAccountForWithdrawlDao
    {
        object Get();

        object Save(AccountForWithdrawl accountForWithdrawl);

        object Search(AccountForWithdrawl accountForWithdrawl);

        object GetAccountForWithdrawl(string offCode, string productCode, string savingAccountNo, string centerCode);

    }
}
