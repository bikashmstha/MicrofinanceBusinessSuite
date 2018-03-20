using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingWithdrawDao
    {


        object SavePublicSavingWithdraw(PublicSavingWithdraw publicSavingWithdraw);

        object SearchPublicSavingWithdraw(PublicSavingWithdraw publicSavingWithdraw);




    }
}
