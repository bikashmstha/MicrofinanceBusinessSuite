using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicAccountCloseAccountDao
    {


        object SavePublicAccountCloseAccount(PublicAccountCloseAccount publicAccountCloseAccount);

        object SearchPublicAccountCloseAccount(PublicAccountCloseAccount publicAccountCloseAccount);



        object GetPubAccCloseAcc(string OfficeCode, string ProductCode, string SavingAccountNo);

    }
}
