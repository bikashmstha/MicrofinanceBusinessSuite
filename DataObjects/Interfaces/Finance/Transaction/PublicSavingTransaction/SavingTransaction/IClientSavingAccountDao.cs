using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IClientSavingAccountDao
    {
        object Get();

        object Save(ClientSavingAccount clientSavingAccount);

        object Search(ClientSavingAccount clientSavingAccount);

        object GetMemberAccountOpen(string offCode, string memberName);

        object GetMemberAccountForCheque(string offCode, string clientNo);

    }
}
