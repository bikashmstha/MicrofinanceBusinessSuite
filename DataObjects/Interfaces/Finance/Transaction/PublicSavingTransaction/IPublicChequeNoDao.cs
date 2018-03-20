using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicChequeNoDao
    {


        object SavePublicChequeNo(PublicChequeNo publicChequeNo);

        object SearchPublicChequeNo(PublicChequeNo publicChequeNo);



        object GetPubChequeNo(string OfficeCode, string AccountNo);

    }
}
