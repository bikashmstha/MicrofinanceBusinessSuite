using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingWithdrawProductDao
    {


        object SavePublicSavingWithdrawProduct(PublicSavingWithdrawProduct publicSavingWithdrawProduct);

        object SearchPublicSavingWithdrawProduct(PublicSavingWithdrawProduct publicSavingWithdrawProduct);



        object GetPubSavWithProd(string ProductName);

    }
}
