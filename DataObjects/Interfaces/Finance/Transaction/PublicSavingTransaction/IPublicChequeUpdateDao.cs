using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicChequeUpdateDao
    {


        object SavePublicChequeUpdate(PublicChequeUpdate publicChequeUpdate);

        object SearchPublicChequeUpdate(PublicChequeUpdate publicChequeUpdate);



        object GetPubChequeUpdate();

    }
}
