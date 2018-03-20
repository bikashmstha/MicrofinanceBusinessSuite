using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicAccountChequeAccountDao
    {


        object SavePublicAccountChequeAccount(PublicAccountChequeAccount publicAccountChequeAccount);

        object SearchPublicAccountChequeAccount(PublicAccountChequeAccount publicAccountChequeAccount);



        object GetPubAccCheqAcc(string OfficeCode, string ProductCode, string SavingAccountNo);

    }
}
