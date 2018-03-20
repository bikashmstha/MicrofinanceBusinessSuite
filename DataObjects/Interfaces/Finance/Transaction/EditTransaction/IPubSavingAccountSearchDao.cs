using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPubSavingAccountSearchDao
    {


        object SavePubSavingAccountSearch(PubSavingAccountSearch pubSavingAccountSearch);

        object SearchPubSavingAccountSearch(PubSavingAccountSearch pubSavingAccountSearch);



        object GetPubSavAccSearch(string OfficeCode, string SavingAccountNo);

    }
}
