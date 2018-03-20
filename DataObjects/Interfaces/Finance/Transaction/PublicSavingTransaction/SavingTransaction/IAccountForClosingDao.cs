using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IAccountForClosingDao
    {
        object Get();

        object Save(AccountForClosing accountForClosing);

        object Search(AccountForClosing accountForClosing);

        object GetAccountForClosing(string offCode, string productCode, string centerCode, string savingAccountNo);

    }
}
