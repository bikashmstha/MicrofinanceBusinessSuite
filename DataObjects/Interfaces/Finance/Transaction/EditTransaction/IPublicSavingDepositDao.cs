using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingDepositDao
    {


        object SavePublicSavingDeposit(PublicSavingDeposit publicSavingDeposit);

        object SearchPublicSavingDeposit(PublicSavingDeposit publicSavingDeposit);




    }
}
