using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicReferenceAccountDao
    {


        object SavePublicReferenceAccount(PublicReferenceAccount publicReferenceAccount);

        object SearchPublicReferenceAccount(PublicReferenceAccount publicReferenceAccount);



        object GetPubRefAcc(string OfficeCode, string ClientNo);

    }
}
