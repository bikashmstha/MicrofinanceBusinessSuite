using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicAccountChequeDao
    {


        object SavePublicAccountCheque(PublicAccountCheque publicAccountCheque);

        object SearchPublicAccountCheque(PublicAccountCheque publicAccountCheque);



        object GetPubAccCheque(string AccountNo, string ChequeNo);

    }
}
