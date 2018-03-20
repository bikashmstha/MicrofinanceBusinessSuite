using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicWithdrawWithAccountDao
    {


        object SavePublicWithdrawWithAccount(PublicWithdrawWithAccount publicWithdrawWithAccount);

        object SearchPublicWithdrawWithAccount(PublicWithdrawWithAccount publicWithdrawWithAccount);



        object GetPubWithAcc(string OfficeCode, string ProductCode, string SavingAccountNo);

    }
}
