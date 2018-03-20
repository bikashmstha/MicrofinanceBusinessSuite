using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IAdjPubSavingAccountDao
    {


        object SaveAdjPubSavingAccount(AdjPubSavingAccount adjPubSavingAccount);

        object SearchAdjPubSavingAccount(AdjPubSavingAccount adjPubSavingAccount);



        object GetAdjPubSavingAcc(string OfficeCode, string ProductCode, string SavingAccountNo);

    }
}
