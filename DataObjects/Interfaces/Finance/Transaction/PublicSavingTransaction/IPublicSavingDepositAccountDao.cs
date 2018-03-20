using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingDepositAccountDao
    {


        object SavePublicSavingDepositAccount(PublicSavingDepositAccount publicSavingDepositAccount);

        object SearchPublicSavingDepositAccount(PublicSavingDepositAccount publicSavingDepositAccount);



        object GetPubSavingDepoAcc(string OfficeCode, string ProductCode, string SavingAccountNo);

    }
}
