using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicClientDao
    {


        object SavePublicClient(PublicClient publicClient);

        object SearchPublicClient(PublicClient publicClient);



        object GetPubClient(string OfficeCode, string ClientName);

    }
}
