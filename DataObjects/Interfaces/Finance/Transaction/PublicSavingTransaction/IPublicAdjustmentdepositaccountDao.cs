using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicAdjustmentdepositaccountDao
    {


        object SavePublicAdjustmentdepositaccount(PublicAdjustmentdepositaccount publicAdjustmentDepositAccount);

        object SearchPublicAdjustmentdepositaccount(PublicAdjustmentdepositaccount publicAdjustmentDepositAccount);



        object GetPubAdjDepoAcc(string OfficeCode, string AccountNo);

    }
}
